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

        [JsonPropertyName("pVRadDataDase")]
        public string PVRadDataDase { get; set; } = "PVGIS-ERA5";

        [JsonPropertyName("pVPeakPower")]
        public int PVPeakPower { get; set; } = 1;

        [JsonPropertyName("pVLoss")]
        public int PVLoss { get; set; } = 14;

        [JsonPropertyName("pVAngle")]
        public int PVAngle { get; set; } = 35;

        [JsonPropertyName("pVAspect")]
        public int? PVAspect { get; set; }

        [JsonPropertyName("energyPrice")]
        public double? EnergyPrice { get; set; } = 0;

        [JsonPropertyName("currencyName")]
        public string CurrencyName { get; set; } = "Грн";

        [JsonPropertyName("investmentPrice")]
        public double? InvestmentPrice { get; set; } = 0;
    }
}
