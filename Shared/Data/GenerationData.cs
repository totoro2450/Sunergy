using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BlazorApp.Shared.Data
{
    public static class GenerationData
    {
        public static double AvgGeneration { get; set; } = 1.06882; // MWt*h per Year
        public static double MinGeneration { get; set; } = 0.0218;  // MWt*h per Month
        public static double MaxGeneration { get; set; } = 0.1355;  // MWt*h per Month
        public static double EnergyPrice { get; set; } = 6393.4;    // Hryvnias / MWt
        public static double EffectiveAreaCooficient { get; set; } = 0.32;
        public static double GenerationCooficient { get; set; } = 4.3;
        public static double InvestmentPrice { get; set; } = 4400;

        public static string PVRadDataDase { get; set; } = "PVGIS-ERA5";
        public static int PVPeakPower { get; set; } = 1;
        public static int PVLoss { get; set; } = 14;
        public static int PVAngle { get; set; } = 35;
        public static int PVAspect { get; set; } = 0;
    }
}
