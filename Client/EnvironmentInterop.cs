using Microsoft.JSInterop;

namespace BlazorApp.Client;

public class EnvironmentInterop
{
    private readonly IJSRuntime _jsRuntime;

    public EnvironmentInterop(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<string> GetEnvironmentVariable(string key)
    {
        return await _jsRuntime.InvokeAsync<string>("getEnvironmentVariable", key);
    }
}