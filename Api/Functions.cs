using System.Net;
using System.Text.Json;
using BlazorApp.Shared;
using BlazorApp.Shared.Classes;
using BlazorApp.Shared.Data;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Api
{
    public class HttpTrigger
    {
        private readonly ILogger _logger;

        public HttpTrigger(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HttpTrigger>();
        }

        [Function("GetMapToken")]
        public HttpResponseData GetMapToken([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {
            _logger.LogInformation("GetMapToken function processed a request.");
            var api_key = Environment.GetEnvironmentVariable("GOOGLE_MAP_API_KEY", EnvironmentVariableTarget.Process);
            api_key ??= Environment.GetEnvironmentVariable("GOOGLE_MAP_API_KEY", EnvironmentVariableTarget.Machine);
            api_key ??= "Token Not Found...";
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.WriteString(api_key);

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
        public async Task<HttpResponseData> GetKnownLocationsAsync([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("GetKnownLocations function processed a request.");
            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(ObjectsData.KnownObjects);

            return response;
        }

        private CalculateResponce CalculateEfficiency(CalculateRequest request)
        {
            if (request == null) throw new Exception("Request is null");
            if (request.RoofArea <= 0) throw new Exception("RoofArea is less than or equal to 0");

            var investmentPrice = request.InvestmentPrice == null || request.InvestmentPrice <= 0
                ? GenerationData.InvestmentPrice
                : (double)request.InvestmentPrice;
            var effectiveArea = request.RoofArea * GenerationData.EffectiveAreaCooficient;
            var totalInvestment = request.RoofArea * investmentPrice;
            var avgGeneration = GenerationData.AvgGeneration * effectiveArea / GenerationData.GenerationCooficient;
            var minGenetation = GenerationData.MinGenetation * effectiveArea / GenerationData.GenerationCooficient;
            var maxGeneration = GenerationData.MaxGeneration * effectiveArea / GenerationData.GenerationCooficient;
            var energyPrice = request.EnergyPrice == null || request.EnergyPrice <= 0
                ? GenerationData.EnergyPrice
                : (double)request.EnergyPrice;
            var income = avgGeneration * GenerationData.EnergyPrice;
            var responce = new CalculateResponce
            {
                Title = request.Title,
                Address = request.Address,
                Coordinates = request.Coordinates,
                RoofArea = request.RoofArea,
                EffectiveRoofArea = effectiveArea,
                RoofAngle = request.RoofAngle ?? 0,
                EnergyPrice = request.EnergyPrice ?? GenerationData.EnergyPrice,
                TotalInvestment = totalInvestment,
                TotalIncome = Math.Round(income, 0),
                AvgGeneration = Math.Round(avgGeneration, 1),
                MinGenetation = Math.Round(minGenetation, 1),
                MaxGeneration = Math.Round(maxGeneration, 1)
            };

            return responce;
        }
    }
}
