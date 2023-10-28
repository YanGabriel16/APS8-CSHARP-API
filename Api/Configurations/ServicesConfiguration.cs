

using APS8_CSHARP_API.Domain.Interfaces.Google;
using APS8_CSHARP_API.Infra.Services.Google;
using APS8_CSHARP_API.Domain.Interfaces;
using APS8_CSHARP_API.Infra.Service;

namespace APS8_CSHARP_API.Configurations
{
    public static class ServicesConfiguration
    {
        public static void AddServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IAirQualityService, AirQualityService>();
            services.AddScoped<IOpenWeatherService, OpenWeatherService>();
        }
    }
}