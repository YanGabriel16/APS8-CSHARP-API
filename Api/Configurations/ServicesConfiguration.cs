

using APS8_CSHARP_API.Domain.Interfaces;
using APS8_CSHARP_API.Infra.Service;

namespace APS8_CSHARP_API.Configurations
{
    public static class ServicesConfiguration
    {
        public static void AddServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IOpenWeatherService, OpenWeatherService>();
        }
    }
}