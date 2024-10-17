namespace BlazorApp.Shared.Classes
{
    public class CalculateResponce
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public Coordinates Coordinates { get; set; }
        public double RoofArea { get; set; }
        public double EffectiveRoofArea { get; set; }
        public double RoofAngle { get; set; }
        public double EnergyPrice { get; set; }
        public string CurrencyName { get; set; }

        // MWt*h per Year
        public double AvgGeneration { get; set; }

        // MWt*h per Month
        public double MinGenetation { get; set; }

        // MWt*h per Month
        public double MaxGeneration { get; set; }

        // Ukrainian hryvnias
        public double TotalInvestment { get; set; }
        
        // Ukrainian cents per Year
        public double TotalIncome { get; set; }
    }
}
