using System.Net;
using System.Text;
using System.Text.Json;
using Azure.Core;
using BlazorApp.Shared.Classes;
using BlazorApp.Shared.Data;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Api
{
    public class HttpTrigger
    {
        private readonly ILogger _logger;
        private HttpClient _httpClient;
        public static string GoogleBaseAddress = "https://maps.googleapis.com/maps/api";
        public static string GooglePlaceUri = "/place/autocomplete/json";
        public static string PVCalcBaseAddress = "https://re.jrc.ec.europa.eu/api";

        public HttpTrigger(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HttpTrigger>();
            _httpClient = new HttpClient();
        }

        [Function("GetMapToken")]
        public HttpResponseData GetMapToken([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {
            _logger.LogInformation("GetMapToken function processed a request.");
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.WriteString(GetApiKey());

            return response;
        }

        [Function("Calculate")]
        public async Task<HttpResponseData> Calculate([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var request = JsonSerializer.Deserialize<CalculateRequest>(requestBody);
            if (request == null)
            {
                var badResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                await badResponse.WriteStringAsync("Invalid request payload.");
                return badResponse;
            }

            var title = request.Title ?? $"{request.Coordinates.Latitude}, {request.Coordinates.Longitude}";
            _logger.LogInformation($"Calculate function processed a request. {title}");
            CalculateResponce result = await CalculateEfficiency(request);
            HttpResponseData response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(result);

            return response;
        }

        [Function("GetKnownLocations")]
        public async Task<HttpResponseData> GetKnownLocations([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("GetKnownLocations function processed a request.");
            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(ObjectsData.KnownObjects);

            return response;
        }

        [Function("GetPredictions")]
        public async Task<HttpResponseData> GetPredictions([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var request = JsonSerializer.Deserialize<GetGoogleMapLocationsRequest>(requestBody);
            var inputType = request?.Inputtype ?? "textquery";
            var input = request?.Input ?? ObjectsData.DefaultCity;

            var url = $"{GoogleBaseAddress}{GooglePlaceUri}?input={Uri.EscapeDataString(input)}&key={GetApiKey()}";

            try
            {
                var res = await _httpClient.GetStringAsync(url);
                var json = JObject.Parse(res);
                var results = json["predictions"];
                var predictions = new List<Location>();

                if (results != null)
                {
                    foreach (var result in results)
                    {
                        var prediction = new Location
                        {
                            Title = result["description"]?.ToString(),
                            Address = result["description"]?.ToString(),
                            LocationSource = LocationSource.Google
                        };
                        predictions.Add(prediction);
                    }
                }

                var response = req.CreateResponse(HttpStatusCode.OK);
                await response.WriteAsJsonAsync(predictions);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching locations: {ex.Message}");
                var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
                await errorResponse.WriteStringAsync("An error occurred while fetching locations.");
                return errorResponse;
            }
        }

        private async Task<CalculateResponce> CalculateEfficiency(CalculateRequest request)
        {
            if (request == null) throw new Exception("Request is null");
            if (request.RoofArea <= 0) throw new Exception("RoofArea is less than or equal to 0");

            var investmentPrice = request.InvestmentPrice == null || request.InvestmentPrice <= 0
                ? GenerationData.InvestmentPrice
                : (double)request.InvestmentPrice;
            var effectiveArea = Math.Round(request.RoofArea * GenerationData.EffectiveAreaCooficient, 2);
            var totalInvestment = request.RoofArea * investmentPrice;
            var generations = await GetGenerationWeight(request);
            var avgGeneration = generations.AvgGeneration * effectiveArea / GenerationData.GenerationCooficient;
            var minGenetation = generations.MinGeneration * effectiveArea / GenerationData.GenerationCooficient;
            var maxGeneration = generations.MaxGeneration * effectiveArea / GenerationData.GenerationCooficient;
            var energyPrice = request.EnergyPrice == null || request.EnergyPrice <= 0
                ? GenerationData.EnergyPrice
                : (double)request.EnergyPrice;
            var income = avgGeneration * energyPrice;
            var responce = new CalculateResponce
            {
                Title = request.Title,
                Address = request.Address,
                Coordinates = request.Coordinates,
                RoofArea = request.RoofArea,
                EffectiveRoofArea = effectiveArea,
                RoofAngle = request.RoofAngle ?? 0,
                EnergyPrice = energyPrice,
                TotalInvestment = totalInvestment,
                TotalIncome = Math.Round(income, 0),
                AvgGeneration = Math.Round(avgGeneration, 1),
                MinGenetation = Math.Round(minGenetation, 1),
                MaxGeneration = Math.Round(maxGeneration, 1),
                CurrencyName = string.IsNullOrWhiteSpace(request.CurrencyName) ? "USD" : request.CurrencyName
            };

            return responce;
        }

        private async Task<GenerationWeight> GetGenerationWeight(CalculateRequest request)
        {
            var coordinates = request.Coordinates;
            var result = new GenerationWeight ();
            var url = GeneratePVGisUrl(request);
            var res = await _httpClient.GetStringAsync(url);
            var json = JObject.Parse(res);

            result.AvgGeneration = (double)json["outputs"]["totals"]["fixed"]["E_y"] / 1000;

            foreach (var month in json["outputs"]["monthly"]["fixed"])
            {
                result.Add((double)month["E_m"] / 1000);
            }

            return result;
        }

        private string GeneratePVGisUrl(CalculateRequest request)
        {
            var url = new StringBuilder();
            url.Append($"{PVCalcBaseAddress}/PVcalc?lat={request.Coordinates.Latitude}&lon={request.Coordinates.Longitude}&outputformat=json");
            
            url.Append($"&peakpower={(request.PVPeakPower > 0 ? request.PVPeakPower : GenerationData.PVPeakPower)}");
            url.Append($"&loss={(request.PVLoss >= 0 ? request.PVLoss : GenerationData.PVLoss)}");
            url.Append($"&angle={(request.PVAngle >= 0 ? request.PVAngle : GenerationData.PVAngle)}");
            if (!string.IsNullOrEmpty(request.PVRadDataDase))
                url.Append($"&raddatabase={request.PVRadDataDase}");
            if (request.PVAspect >= 0)
                url.Append($"&aspect={request.PVAspect}");

            return url.ToString();
        }

        private class GenerationWeight
        {
            public List<double> Generations { get; set; } = [];
            public double AvgGeneration { get; set; }
            public double MinGeneration { get => Generations.Any()? Generations.Min(): GenerationData.MinGeneration; }
            public double MaxGeneration { get => Generations.Any() ? Generations.Max() : GenerationData.MaxGeneration; }

            public void Add(double generation)
            {
                Generations.Add(generation);
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append('[');
                foreach (var generation in Generations)
                {
                    sb.Append(generation);
                    sb.Append(", ");
                }
                sb.Append(']');
                return sb.ToString();
            }
        }

        private string GetApiKey()
        {
            var api_key = Environment.GetEnvironmentVariable("GOOGLE_MAP_API_KEY", EnvironmentVariableTarget.Process);
            api_key ??= Environment.GetEnvironmentVariable("GOOGLE_MAP_API_KEY", EnvironmentVariableTarget.Machine);
            api_key ??= "Token Not Found...";

            return api_key;
        }
    }
}
