using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp.Shared.Data
{
    public static class GenerationData
    {
        public static double AvgGeneration { get; set; } = 1.06882;
        public static double MinGenetation { get; set; } = 0.0218;
        public static double MaxGeneration { get; set; } = 0.1355;
        public static double EnergyPrice { get; set; } = 640;
        public static double EffectiveAreaCooficient { get; set; } = 0.32;
        public static double GenerationCooficient { get; set; } = 4.3;
        public static double InvestmentPrice { get; set; } = 4400;
    }
}
