using GoogleMapsComponents.Maps;

namespace BlazorApp.Client.Extensions
{
    public static class CoordinatesExtensions
    {
        public static LatLngLiteral ToLatLngLiteral(this Shared.Classes.Coordinates coordinates)
        {
            return new LatLngLiteral
            {
                Lat = coordinates.Latitude,
                Lng = coordinates.Longitude
            };
        }

        public static Shared.Classes.Coordinates ToCoordinates(this LatLngLiteral latLngLiteral)
        {
            return new Shared.Classes.Coordinates
            {
                Latitude = latLngLiteral.Lat,
                Longitude = latLngLiteral.Lng
            };
        }
    }
}
