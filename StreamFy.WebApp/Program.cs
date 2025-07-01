using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using StreamFy.WebApp;
using StreamFy.WebApp.Requests;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://streamfyapi.azurewebsites.net") });
builder.Services.AddScoped<UsuarioEndpoint>();
builder.Services.AddScoped<MusicaEndpoint>();

builder.Services.AddMudServices();

await builder.Build().RunAsync();