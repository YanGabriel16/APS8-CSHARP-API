using APS8_CSHARP_API.Domain.Extensions;
using APS8_CSHARP_API.Domain.Helpers;
using APS8_CSHARP_API.Domain.Interfaces;
using Hangfire;
using HangfireBasicAuthenticationFilter;

namespace APS8_CSHARP_API.Api.Configurations
{
    public static class HangfireConfiguration
    {
        public static void AddHangfireConfiguration(this IServiceCollection services)
        {
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(Constants.ConnectionString));

            services.AddHangfireServer();
        }

        public static void UseHangfireConfiguration(this IApplicationBuilder app)
        {
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new HangfireCustomBasicAuthenticationFilter { User = "admin", Pass = "admin" } }
            });

            app.AddHangfireJobs();
        }

        private static void AddHangfireJobs(this IApplicationBuilder _)
        {
            RecurringJob.AddOrUpdate<IHangfireJobService>("Job :: ApiOn", x => x.ApiOn(), CronExtensions.Minutely(5));
        }
    }
}