using System.Text.Json.Serialization;

namespace BlazorApp.Shared.Classes
{
    public class PlacesPrediction
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("locationSource")]
        public LocationSource LocationSource { get; set; } = LocationSource.Google;
    }
}
