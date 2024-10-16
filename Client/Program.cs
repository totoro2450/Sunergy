using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApp.Client;
using GoogleMapsComponents;
using BlazorApp.Shared.Laguage;
using BlazorApp.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

var mapKeyResponse = "";
var baseAddress = "";

if (builder.HostEnvironment.IsDevelopment())
    baseAddress = "http://localhost:7071";
else
    baseAddress = builder.HostEnvironment.BaseAddress;

var httpClient = new HttpClient { BaseAddress = new Uri(builder.Configuration["API_Prefix"] ?? builder.HostEnvironment.BaseAddress) };
try {
    // using var httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };
    mapKeyResponse = await httpClient.GetStringAsync("api/GetMapToken");
    if (string.IsNullOrEmpty(mapKeyResponse)) mapKeyResponse = "TokenNotFound";
}
catch {
    mapKeyResponse = "TokenNotFound";
}

builder.Services.AddBlazorGoogleMaps(mapKeyResponse);

builder.Services.AddScoped(sp => httpClient);
builder.Services.AddSingleton(lngService => new LanguageService(nameof(LanguageData.Ukrainian)));
builder.Services.AddSingleton(s => new NetworkService(httpClient, mapKeyResponse, baseAddress));

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

await builder.Build().RunAsync();
