using System.Net;
using BlazorApp.Shared;
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

        [Function("HttpExample")]
        public HttpResponseData HttpExample([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.WriteString("Example Here!");
            return response;
        }

        [Function("WeatherForecast")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {
            _logger.LogInformation("WeatherForecast function processed a request.");
            Console.WriteLine("C# HTTP trigger function processed a request. WeatherForecast");
            var randomNumber = new Random();
            var temp = 0;

            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = temp = randomNumber.Next(-20, 55),
                Summary = GetSummary(temp)
            }).ToArray();

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.WriteAsJsonAsync(result);

            return response;
        }

        [Function("GetMapToken")]
        public HttpResponseData GetMapToken([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "map/GetMapToken")] HttpRequestData req)
        {
            _logger.LogInformation("GetMapToken function processed a request.");
            Console.WriteLine("C# HTTP trigger function processed a request. GetMapToken");
            var token = Environment.GetEnvironmentVariable("GOOGLE_MAPS_TOKEN");
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.WriteString("token!");

            return response;
        }

        private string GetSummary(int temp)
        {
            var summary = "Mild";

            if (temp >= 32)
            {
                summary = "Hot";
            }
            else if (temp <= 16 && temp > 0)
            {
                summary = "Cold";
            }
            else if (temp <= 0)
            {
                summary = "Freezing";
            }

            return summary;
        }
    }
}
