using APS8_CSHARP_API.Domain.Interfaces.Repository;
using APS8_CSHARP_API.Infra.Repository;

namespace APS8_CSHARP_API.Configurations
{
    public static class RepositoryConfiguration
    {
        public static void AddRepositoryConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ILocalRepository, LocalRepository>();
        }
    }
}