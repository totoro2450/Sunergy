using GoogleMapsComponents.Maps;

namespace BlazorApp.Client.Extensions
{
    public static class CoordinatesExtensions
    {
        public static LatLngLiteral ToLatLngLiteral(this BlazorApp.Shared.Classes.Coordinates coordinates)
        {
            return new LatLngLiteral
            {
                Lat = coordinates.Latitude,
                Lng = coordinates.Longitude
            };
        }
    }
}
