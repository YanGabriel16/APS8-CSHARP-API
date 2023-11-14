using APS8_CSHARP_API.Domain.Interfaces.Google;
using APS8_CSHARP_API.Infra.Services.Google;
using APS8_CSHARP_API.Domain.Interfaces;
using APS8_CSHARP_API.Infra.Services;
using APS8_CSHARP_API.Infra.UnitOfWork;

namespace APS8_CSHARP_API.Configurations
{
    public static class ServicesConfiguration
    {
        public static void AddServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IHangfireJobService, HangfireJobService>();
            services.AddScoped<IOpenWeatherService, OpenWeatherService>();
            services.AddScoped<IViaCEPService, ViaCEPService>();
            services.AddScoped<IGeoCodeService, GeoCodeService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}