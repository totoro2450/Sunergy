using System.Text.Json.Serialization;

namespace BlazorApp.Shared.Classes
{
    public class Coordinates
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }
    }
}
