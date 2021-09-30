using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SerieFlix.WebApp.Configurations;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Syncfusion.Blazor;

namespace SerieFlix.WebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("@31392e322e30lvEeFouSRwSf/qqWQmAhfmIoTLBm8PtFlVopwxgHbvE=");

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://serieflixapi.azurewebsites.net/api/") });
            builder.Services.AddHttpClient("SerieFlixApi", client => {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            });
            builder.Services.AddSyncfusionBlazor();
            

            DependencyInjection.Resolve(builder.Services);

            await builder.Build().RunAsync();
        }
    }
}
