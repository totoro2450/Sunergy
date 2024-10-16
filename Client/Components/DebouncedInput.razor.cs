using System.Reactive.Linq;
using System.Reactive.Subjects;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Client.Components
{
    public partial class DebouncedInput
    {
        private Subject<string> _subject = new Subject<string>();
        private IDisposable? _subscription;

        [Parameter]
        public string Value { get; set; } = string.Empty;

        [Parameter]
        public string Placeholder { get; set; } = string.Empty;

        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }

        [Parameter]
        public int DebounceMilliseconds { get; set; } = 1000;

        protected override void OnInitialized()
        {
            _subscription = _subject
                .Throttle(TimeSpan.FromMilliseconds(DebounceMilliseconds))
                .DistinctUntilChanged()
                .Subscribe(async value => await ValueChanged.InvokeAsync(value));
        }

        private void OnInput(ChangeEventArgs e)
        {
            _subject.OnNext(e.Value?.ToString() ?? string.Empty);
        }

        public void Dispose()
        {
            _subscription?.Dispose();
            _subject?.Dispose();
        }
    }
}
