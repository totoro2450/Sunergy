namespace BlazorApp.Shared.Classes
{
    public class Location
    {
        public string Title { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public Coordinates Coordinates { get; set; } = new Coordinates();
        public LocationSource LocationSource { get; set; } = LocationSource.Known;
    }
}
