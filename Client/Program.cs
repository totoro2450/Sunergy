using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApp.Client;
using GoogleMapsComponents;
using Microsoft.JSInterop;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// var mapKey = Environment.GetEnvironmentVariable("GOOGLE_MAP_API_KEY");
var environmentVariables = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Machine);
var mapKey = "AIzaSyDM357oskRNJ_s4RB1ZRGzZu9-mIgMQTqI";
builder.Services.AddBlazorGoogleMaps(mapKey);
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["API_Prefix"] ?? builder.HostEnvironment.BaseAddress) });

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

await builder.Build().RunAsync();
