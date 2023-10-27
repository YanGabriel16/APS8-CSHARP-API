using APS8_CSHARP_API.Api.Configurations;
using APS8_CSHARP_API.Configurations;

namespace APS8_CSHARP_API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataBaseConfiguration(Configuration);
            services.AddControllers();
            services.AddCorsConfiguration();
            services.AddSwaggerConfiguration();
            services.AddServicesConfiguration();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthorization();
            app.UseSwaggerConfiguration();
            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("APS8 API no ar!");
            });
        }
    }
}
