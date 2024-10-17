using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
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
            CalculateResponce result = CalculateEfficiency(request);
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

        private CalculateResponce CalculateEfficiency(CalculateRequest request)
        {
            if (request == null) throw new Exception("Request is null");
            if (request.RoofArea <= 0) throw new Exception("RoofArea is less than or equal to 0");

            var investmentPrice = request.InvestmentPrice == null || request.InvestmentPrice <= 0
                ? GenerationData.InvestmentPrice
                : (double)request.InvestmentPrice;
            var effectiveArea = Math.Round(request.RoofArea * GenerationData.EffectiveAreaCooficient, 2);
            var totalInvestment = request.RoofArea * investmentPrice;
            var avgGeneration = GenerationData.AvgGeneration * effectiveArea / GenerationData.GenerationCooficient;
            var minGenetation = GenerationData.MinGenetation * effectiveArea / GenerationData.GenerationCooficient;
            var maxGeneration = GenerationData.MaxGeneration * effectiveArea / GenerationData.GenerationCooficient;
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

        private string GetApiKey()
        {
            var api_key = Environment.GetEnvironmentVariable("GOOGLE_MAP_API_KEY", EnvironmentVariableTarget.Process);
            api_key ??= Environment.GetEnvironmentVariable("GOOGLE_MAP_API_KEY", EnvironmentVariableTarget.Machine);
            api_key ??= "Token Not Found...";

            return api_key;
        }
    }
}
