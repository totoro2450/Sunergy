using GoogleMapsComponents;
using GoogleMapsComponents.Maps;

namespace BlazorApp.Client.Layout
{
    public partial class Calculator
    {
        private GoogleMap _map1 = default!;
        private MapOptions _mapOptions = default!;
        private List<string> _events = [];
        private Stack<Marker> _markers = new();
        private string _labelText = "";

        protected override void OnInitialized()
        {
            _mapOptions = new MapOptions()
            {
                Zoom = 13,
                Center = new LatLngLiteral()
                {
                    Lat = 13.505892,
                    Lng = 100.8162
                },
                MapTypeId = MapTypeId.Roadmap
            };
        }

        private async Task OnAfterInitAsync()
        {
            //Debug.WriteLine("Start OnAfterRenderAsync");
            await _map1.InteropObject.AddListener("bounds_changed", OnBoundsChanged);
            await _map1.InteropObject.AddListener("center_changed", OnCenterChanged);
            await _map1.InteropObject.AddListener<MouseEvent>("click", async (e) => await OnClick(e));
            await _map1.InteropObject.AddListener("dblclick", OnDoubleClick);
            await _map1.InteropObject.AddListener("drag", OnDrag);
            await _map1.InteropObject.AddListener("dragend", OnDragEnd);
            await _map1.InteropObject.AddListener("dragstart", OnDragStart);
            await _map1.InteropObject.AddListener("heading_changed", OnHeadingChanged);
            await _map1.InteropObject.AddListener("idle", OnIdle);
            await _map1.InteropObject.AddListener("maptypeid_changed", OnMapTypeIdChanged);
            await _map1.InteropObject.AddListener<MouseEvent>("mousemove", OnMouseMove);
            await _map1.InteropObject.AddListener("mouseout", OnMouseOut);
            await _map1.InteropObject.AddListener("mouseover", OnMouseOver);
            await _map1.InteropObject.AddListener("projection_changed", OnProjectionChanged);
            await _map1.InteropObject.AddListener("rightclick", OnRightClick);
            await _map1.InteropObject.AddListener("tilesloaded", OnTilesLoaded);
            await _map1.InteropObject.AddListener("tilt_changed", OnTiltChanged);
            await _map1.InteropObject.AddListener("zoom_changed", OnZoomChanged);
        }

        private void OnBoundsChanged()
        {
            _events.Insert(0, "Bounds changed.");
            _events = _events.Take(100).ToList();
            StateHasChanged();
        }

        private void OnCenterChanged()
        {
            _events.Insert(0, "Center changed.");
            _events = _events.Take(100).ToList();
            StateHasChanged();
        }

        private async Task OnClick(MouseEvent e)
        {
            _events.Insert(0, $"Click {e.LatLng}.");
            _events = _events.Take(100).ToList();

            StateHasChanged();
        }

        private void OnDoubleClick()
        {
            _events.Insert(0, "Double click.");
            _events = _events.Take(100).ToList();

            StateHasChanged();
        }

        private void OnDrag()
        {
            _events.Insert(0, "Drag.");
            _events = _events.Take(100).ToList();

            StateHasChanged();
        }

        private void OnDragEnd()
        {
            _events.Insert(0, "Drag end.");

            StateHasChanged();
        }

        private void OnDragStart()
        {
            _events.Insert(0, "Drag start.");
            _events = _events.Take(100).ToList();

            StateHasChanged();
        }

        private void OnHeadingChanged()
        {
            _events.Insert(0, "Heading changed.");
            _events = _events.Take(100).ToList();

            StateHasChanged();
        }

        private void OnIdle()
        {
            _events.Insert(0, "Idle.");
            _events = _events.Take(100).ToList();

            StateHasChanged();
        }

        private void OnMapTypeIdChanged()
        {
            _events.Insert(0, "OnMapTypeIdChanged.");
            _events = _events.Take(100).ToList();

            StateHasChanged();
        }

        private void OnMouseMove(MouseEvent e)
        {
            _events.Insert(0, $"OnMouseMove {e.LatLng}.");
            _events = _events.Take(100).ToList();

            StateHasChanged();
        }

        private void OnMouseOut()
        {
            _events.Insert(0, "OnMouseOut.");
            _events = _events.Take(100).ToList();

            StateHasChanged();
        }

        private void OnMouseOver()
        {
            _events.Insert(0, "OnMouseOver.");

            StateHasChanged();
        }

        private void OnProjectionChanged()
        {
            _events.Insert(0, "OnProjectionChanged.");

            StateHasChanged();
        }

        private void OnRightClick()
        {
            _events.Insert(0, "OnRightClick.");

            StateHasChanged();
        }

        private void OnTilesLoaded()
        {
            _events.Insert(0, "OnTilesLoaded.");

            StateHasChanged();
        }

        private void OnTiltChanged()
        {
            _events.Insert(0, "OnTiltChanged.");

            StateHasChanged();
        }

        private void OnZoomChanged()
        {
            _events.Insert(0, "OnZoomChanged.");

            StateHasChanged();
        }

        private async Task AddMarker()
        {
            var markerOptions = new MarkerOptions()
            {
                Position = await _map1.InteropObject.GetCenter(),
                Map = _map1.InteropObject,
                Label = new MarkerLabel { Text = $"Test {_markers.Count()}", FontWeight = "bold" },
                Draggable = true,
                Icon = new Icon()
                {
                    Url =
                        "https://developers.google.com/maps/documentation/javascript/examples/full/images/beachflag.png"
                }
                //Icon = "https://developers.google.com/maps/documentation/javascript/examples/full/images/beachflag.png"
            };
            var marker = await Marker.CreateAsync(_map1.JsRuntime, markerOptions);
            var icon = await marker.GetIcon();

            Console.WriteLine($"Get icon result type is : {icon.Value.GetType()}");

            icon.Switch(
                s => Console.WriteLine(s),
                i => Console.WriteLine(i.Url),
                _ => { });

            _markers.Push(marker);
            _labelText = await marker.GetLabelText();

            await marker.AddListener<MouseEvent>("click", async e =>
            {
                string markerLabelText = await marker.GetLabelText();
                _events.Add("click on " + markerLabelText);
                StateHasChanged();
                await e.Stop();
            });
            await marker.AddListener<MouseEvent>("dragend", async e => await OnMakerDragEnd(marker, e));
        }

        private async Task OnMakerDragEnd(Marker m, MouseEvent e)
        {
            string markerLabelText = await m.GetLabelText();
            _events.Insert(0, $"OnMakerDragEnd ({markerLabelText}): ({e.LatLng}).");
            StateHasChanged();
            await e.Stop();
        }

        private async Task RemoveMarker()
        {
            if (!_markers.Any())
            {
                return;
            }

            var lastMarker = _markers.Pop();
            await lastMarker.SetMap(null);
            _labelText = _markers.Any() ? await _markers.Peek().GetLabelText() : "";
        }
    }
}
