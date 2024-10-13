using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BlazorApp.Shared.Classes
{
    public class CalculateRequest
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("coordinates")]
        public Coordinates Coordinates { get; set; }

        [JsonPropertyName("perimeter")]
        public List<Coordinates> Perimeter { get; set; } = new List<Coordinates>();

        [JsonPropertyName("roofArea")]
        public double RoofArea { get; set; }

        [JsonPropertyName("roofAngle")]
        public double? RoofAngle { get; set; }

        [JsonPropertyName("energyPrice")]
        public double? EnergyPrice { get; set; }

        [JsonPropertyName("effectiveAreaCooficient")]
        public double? InvestmentPrice { get; set; }
    }
}
