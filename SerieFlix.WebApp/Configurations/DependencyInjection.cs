using Microsoft.Extensions.DependencyInjection;
using SerieFlix.WebApp.Core.Contracts;
using SerieFlix.WebApp.Core.Services;

namespace SerieFlix.WebApp.Configurations
{
    public static class DependencyInjection
    {
        public static void Resolve(IServiceCollection services)
        {
            services.AddScoped<ISerieServices, SerieServices>();
        }
    }
}
