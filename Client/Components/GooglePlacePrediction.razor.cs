using BlazorApp.Shared.Classes;
using GoogleMapsComponents.Maps.Places;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Client.Components
{
    public partial class GooglePlacePrediction
    {
        [Parameter]
        public AutocompleteOptions? Options { get; set; }

        [Parameter]
        public string SearchString { get; set; } = string.Empty;

        private Location Location { get; set; } = new Location();
        private Autocomplete Autocomplete { get; set; }
        private ElementReference AutocompleteRef { get; set; }

        private async Task OnAfterInitAsync()
        {
            Options ??= new AutocompleteOptions
            {
                Types = new[] { "geocode" }
            };

            Autocomplete = await Autocomplete.CreateAsync(JSRuntime, AutocompleteRef, Options);
            await Autocomplete.AddListener("place_changed", OnPlaceChanged);

            // await _autocomplete.AddListener("bounds_changed", OnBoundsChanged); 
            // await _autocomplete.AddListener("input_changed", OnInputChanged);
        }

        private async void OnPlaceChanged()
        {
            var place = await Autocomplete.GetPlace();
            if (place.Geometry != null)
            {
                var location = new Location()
                {
                    Title = place.Name,
                    Address = place.FormattedAddress,
                    Coordinates = new Coordinates
                    {
                        Latitude = place.Geometry.Location!.Lat,
                        Longitude = place.Geometry.Location!.Lng
                    }
                };

                StateHasChanged();
            }
        }
    }
}
