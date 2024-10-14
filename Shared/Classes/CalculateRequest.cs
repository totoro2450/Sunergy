using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BlazorApp.Shared.Classes
{
    public class CalculateRequest
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;

        [JsonPropertyName("coordinates")]
        public Coordinates Coordinates { get; set; } = new Coordinates();

        [JsonPropertyName("perimeter")]
        public List<Coordinates> Perimeter { get; set; } = new List<Coordinates>();

        [JsonPropertyName("roofArea")]
        public double RoofArea { get; set; } = 0;

        [JsonPropertyName("roofAngle")]
        public double? RoofAngle { get; set; } = 0;

        [JsonPropertyName("energyPrice")]
        public double? EnergyPrice { get; set; } = 0;

        [JsonPropertyName("currencyName")]
        public string CurrencyName { get; set; } = "USD";

        [JsonPropertyName("investmentPrice")]
        public double? InvestmentPrice { get; set; } = 0;
    }
}
