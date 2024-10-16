using BlazorApp.Shared.Classes;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;
using System.Text.Json;

namespace BlazorApp.Client.Services
{
    public class NetworkService(HttpClient client, string apiGoogleKey, string apiBaseAddress)
    {
        public const string LocalhostApiUri = "http://localhost";
        public const string LocalHostApiPort = "7071";

        public string ApiKey { get; private set; } = apiGoogleKey;
        public string BaseAddress { get; private set; } = "https://maps.googleapis.com/maps/api";
        public string GeocodeUri { get; private set; } = "/geocode/json?";
        public string PlaceUri { get; private set; } = "/place/findplacefromtext/json?";
        public string ApiBaseAddress { get; private set; } = apiBaseAddress;
        public string ApiKnownLocationsUri { get; private set; } = "/api/GetKnownLocations";
        public string ApiPlacePredictionsUri { get; private set; } = "/api/GetPredictions";
        public string ApiCalculateUri { get; private set; } = "/api/Calculate";
        public HttpClient Client { get; private set; } = client;
        private List<CalculateRequest> KnownLocaltions { get; set; } = [];
        private DateTime CacheTime { get; set; } = DateTime.MinValue;
        private int CacheTimeMinutes { get; set; } = 5;

        public async Task<List<PlacesPrediction>> GetPredictions(string input)
        {
            var results = new List<PlacesPrediction>();
            var knownPredictions = await GetKnownPredictions(input);
            var googlePredictions = await GetGooglePredictions(input);
            results.AddRange(knownPredictions);
            results.AddRange(googlePredictions);

            return results;
        }

        public async Task<CalculateRequest> GetLocation(PlacesPrediction placesPrediction)
        {
            return placesPrediction.LocationSource switch
            {
                LocationSource.Google => await GetGoogleLocation(placesPrediction.Description),
                LocationSource.Known => await GetKnownLocation(placesPrediction.Description),
                _ => new CalculateRequest { Address = placesPrediction.Description, Title = placesPrediction.Description },
            };
        }

        public async Task<List<PlacesPrediction>> GetGooglePredictions(string input)
        {
            try
            {
                var content = JsonSerializer.Serialize(new GetGoogleMapLocationsRequest(input));
                var response = await Client.PostAsync($"{ApiBaseAddress}{ApiPlacePredictionsUri}", new StringContent(content));
                if (!response.IsSuccessStatusCode)
                    throw new Exception(response.ReasonPhrase);

                var predictions = await response.Content.ReadFromJsonAsync<List<PlacesPrediction>>();
                if (predictions != null && predictions.Count > 0)
                    return predictions;
                else
                    return [];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<CalculateRequest> GetGoogleLocation(string address)
        {
            var url = $"{BaseAddress}{GeocodeUri}address={Uri.EscapeDataString(address)}&key={ApiKey}";
            var response = await Client.GetStringAsync(url);

            var json = JObject.Parse(response);
            var results = json["results"];
            var location = json["results"]![0]!["geometry"]!["location"];

            var result = new CalculateRequest
            {
                Title = address,
                Address = address,
                Coordinates = new Coordinates((double)location!["lat"]!, (double)location!["lng"]!)
            };

            return result;
        }

        public async Task<CalculateRequest> GetKnownLocation(string title)
        {
            await GetKnownLocations();
            return KnownLocaltions.FirstOrDefault(l => l.Title == title)!;
        }

        public async Task<List<PlacesPrediction>> GetKnownPredictions(string input)
        {
            await GetKnownLocations();
            var searchString = input.ToLower();
            return KnownLocaltions.Where(l => l.Title.Contains(searchString, StringComparison.CurrentCultureIgnoreCase) ||
            l.Address.Contains(searchString, StringComparison.CurrentCultureIgnoreCase))
                .Select(l => new PlacesPrediction
                {
                    Description = l.Title,
                    Address = l.Address,
                    LocationSource = LocationSource.Known
                }).Take(5).ToList();
        }

        public async Task<CalculateResponce> Calculate(CalculateRequest? request)
        {
            try
            {
                var response = await Client.PostAsJsonAsync($"{ApiBaseAddress}{ApiCalculateUri}", request);
                if (!response.IsSuccessStatusCode)
                    throw new Exception(response.ReasonPhrase);
                var result = await response.Content.ReadFromJsonAsync<CalculateResponce>();
                if (result == null)
                    throw new Exception("No data received from server");

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private async Task GetKnownLocations()
        {
            var isCacheValid = IsCacheValid();
            if (IsCacheValid()) return;
            var url = $"{ApiBaseAddress}{ApiKnownLocationsUri}";

            try
            {
                var response = await Client.PostAsJsonAsync(url, new { });
                var result = await response.Content.ReadFromJsonAsync<List<CalculateRequest>>();
                KnownLocaltions = result!;
                CacheTime = DateTime.Now.AddMinutes(CacheTimeMinutes);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private bool IsCacheValid()
        {
            return CacheTime > DateTime.Now;
        }
    }
}
