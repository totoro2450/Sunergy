using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApp.Client;
using GoogleMapsComponents;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["API_Prefix"] ?? builder.HostEnvironment.BaseAddress) });
var mapKey = "AIzaSyDM357oskRNJ_s4RB1ZRGzZu9-mIgMQTqI";
builder.Services.AddBlazorGoogleMaps(mapKey);

await builder.Build().RunAsync();
