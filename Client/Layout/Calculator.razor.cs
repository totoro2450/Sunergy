using GoogleMapsComponents.Maps;
using GoogleMapsComponents;
using Microsoft.AspNetCore.Components;
using BlazorApp.Shared.Classes;
using System.Net.Http.Json;
using BlazorApp.Client.Extensions;

namespace BlazorApp.Client.Layout
{
    public partial class Calculator : ComponentBase
    {
        public const string LocalhostApiUri = "http://localhost";
        public const string LocalHostApiPort = "7071";
        public static readonly Coordinates DefaultCoordinates = new(51.521654, 30.754540);
        private string BaseAddress = "";
        private static int DefaultZoom = 15;
        private GoogleMap _map1 = default!;
        private bool _showLocationsList = false;
        private bool _showDetails = false;
        private CalculateRequest? CurrentRequest;
        private CalculateResponce? CurrentResponce;
        private List<CalculateRequest> KnownLocaltions = [];
        private bool ContainErrors = false;
        private List<string> Errors = [];
        private MapOptions _mapOptions = default!;
        private Stack<Marker> _markers = new Stack<Marker>();

        protected override void OnInitialized()
        {
            _mapOptions = new MapOptions()
            {
                Zoom = DefaultZoom,
                Center = DefaultCoordinates.ToLatLngLiteral(),
                MapTypeId = MapTypeId.Roadmap
            };
        }

        private async Task OnAfterInitAsync()
        {
            await GetKnownLocations();

            await _map1.InteropObject.AddListener<MouseEvent>("click", async (e) => await OnClick(e));
        }

        private void UpdateCurrentBaseAddress()
        {
            var baseAddress = NavigationManager.BaseUri;
            if (baseAddress.StartsWith(LocalhostApiUri))
                BaseAddress = $"{LocalhostApiUri}:{LocalHostApiPort}";
            else
                BaseAddress = baseAddress;
        }

        private async Task Calculate()
        {
            ClearErrors();
            try
            {
                var response = await Http.PostAsJsonAsync($"{BaseAddress}/api/Calculate", CurrentRequest);
                if (!response.IsSuccessStatusCode)
                {
                    SetError(LanguageService.GetTraslation(Shared.Language.LanguageKeys.ServerError));
                    Console.WriteLine(response.ReasonPhrase);
                    return;
                }
                var result = await response.Content.ReadFromJsonAsync<CalculateResponce>();
                CurrentResponce = result;
            }
            catch (Exception ex)
            {
                SetError(LanguageService.GetTraslation(Shared.Language.LanguageKeys.ServerError));
                Console.WriteLine(ex.Message);
            }
        }

        private async Task GetKnownLocations()
        {
            try
            {
                var response = await Http.PostAsync($"{BaseAddress}/api/GetKnownLocations", new StringContent(""));
                if (!response.IsSuccessStatusCode)
                {
                    KnownLocaltions = [];
                    return;
                }
                var knownLocaltions = await response.Content.ReadFromJsonAsync<List<CalculateRequest>>();
                if (knownLocaltions != null && knownLocaltions.Count > 0)
                    KnownLocaltions = knownLocaltions;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            StateHasChanged();
        }

        private bool IsValidRequest()
        {
            if (CurrentRequest == null) return false;
            if (CurrentRequest.RoofArea <= 0) return false;
            if (string.IsNullOrEmpty(CurrentRequest.Title)) return false;
            return true;
        }

        private async Task AddNewLocation()
        {
            CurrentRequest = new CalculateRequest();
            var mapCenter = await _map1.InteropObject.GetCenter();

            CurrentRequest.Coordinates = mapCenter == null
                ? DefaultCoordinates
                : mapCenter.ToCoordinates();

            _showLocationsList = false;
        }

        private async Task OnLocationSelect(CalculateRequest request)
        {
            if (request == null) return;
            CurrentRequest = request;
            await AddMarker(request.Coordinates);
            await ShowMarkerOnMap(request.Coordinates);
            await SetZoom(17);
            HideLocationsList();
        }

        private void ShowLocationsList()
        {
            _showLocationsList = true;
        }

        private void HideLocationsList()
        {
            _showLocationsList = false;
        }

        private void ToggleLocationsList()
        {
            _showLocationsList = !_showLocationsList;
        }

        private void ToggleDetails()
        {
            _showDetails = !_showDetails;
        }

        private void SetCoordinates(LatLngLiteral latLngLiteral)
        {
            if (CurrentRequest == null) return;
            CurrentRequest.Coordinates = latLngLiteral.ToCoordinates();
        }

        private async Task OnClick(MouseEvent e)
        {
            Console.WriteLine($"Click Lng: {e.LatLng.Lng}; Lat: {e.LatLng.Lat}");
            SetCoordinates(e.LatLng);
            await AddMarker(e.LatLng);

            StateHasChanged();
            // e.Stop();
        }

        private async Task AddMarker(LatLngLiteral latLngLiteral)
        {
            await AddMarker(latLngLiteral.ToCoordinates());
        }

        private async Task AddMarker(Coordinates coordinates)
        {
            await RemoveMarker();

            var position = coordinates.ToLatLngLiteral();
            var title = " ";
            if (CurrentRequest == null)
                title = $"{position.Lat}, {position.Lng}";
            else
                title = string.IsNullOrWhiteSpace(CurrentRequest.Title) ? " " : CurrentRequest.Title;

            var marker = await Marker.CreateAsync(_map1.JsRuntime,
                new MarkerOptions()
                {
                    Position = position,
                    Map = _map1.InteropObject,
                    Label = new MarkerLabel { Text = title, FontWeight = "normal" },
                    Draggable = false
                }
            );

            _markers.Push(marker);
        }

        private async Task RemoveMarker()
        {
            if (!_markers.Any())
            {
                return;
            }

            var lastMarker = _markers.Pop();
            await lastMarker.SetMap(null);
        }

        private async Task ShowMarkerOnMap(Coordinates position)
        {
            await _map1.InteropObject.SetCenter(position.ToLatLngLiteral());
        }

        private async Task SetZoom(int zoomLevel = 16)
        {
            await _map1.InteropObject.SetZoom(zoomLevel);
        }

        private string MakeNumberReadable(double number)
        {
            return number.ToString("N0");
        }

        private void SetError(string errorMessage)
        {
            ContainErrors = true;
            Errors.Clear();
            Errors.Add(errorMessage);
        }

        private void AddError(string errorMessage)
        {
            ContainErrors = true;
            Errors.Add(errorMessage);
        }

        private void ClearErrors()
        {
            ContainErrors = false;
            Errors.Clear();
        }

        private void RemoveError(string errorMessage)
        {
            Errors.Remove(errorMessage);
            if (Errors.Count == 0)
                ContainErrors = false;
        }
    }
}
