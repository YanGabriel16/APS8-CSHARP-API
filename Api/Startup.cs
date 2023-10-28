using APS8_CSHARP_API.Api.Configurations;
using APS8_CSHARP_API.Configurations;
using Hangfire;

namespace APS8_CSHARP_API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
            => Configuration = configuration;
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataBaseConfiguration();
            services.AddControllers();
            services.AddCorsConfiguration();
            services.AddHangfireConfiguration();
            services.AddSwaggerConfiguration();
            services.AddServicesConfiguration();
            services.AddRepositoryConfiguration();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseSwaggerConfiguration();
            app.UseHangfireConfiguration();
            app.UseCors("CorsPolicy");
            
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.Run(async (context) => await context.Response.WriteAsync("APS8 API no ar!"));
        }
    }
}
