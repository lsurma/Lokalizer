using Lokalizer.Abstractions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;
using Lokalizer.Host.WA;
using Lokalizer.Host.WA.DAL;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:7233/api/")
});
builder.Services.AddScoped<IRequestSender, HttpRequestSender>();

builder.Services.AddFluentUIComponents();

await builder.Build().RunAsync();