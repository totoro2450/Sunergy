using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApp.Client;
using GoogleMapsComponents;
using BlazorApp.Shared.Laguage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

var mapKeyResponse = "";
var baseAddress = "";

if (builder.HostEnvironment.IsDevelopment())
    baseAddress = "http://localhost:7071";
else
    baseAddress = builder.HostEnvironment.BaseAddress;

using var httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };
Console.WriteLine("Uri: " + new Uri(builder.HostEnvironment.BaseAddress));
mapKeyResponse = await httpClient.GetStringAsync("api/GetMapToken");

builder.Services.AddBlazorGoogleMaps(mapKeyResponse);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["API_Prefix"] ?? builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton(lngService => new LanguageService(nameof(LanguageData.Ukrainian)));

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

await builder.Build().RunAsync();
