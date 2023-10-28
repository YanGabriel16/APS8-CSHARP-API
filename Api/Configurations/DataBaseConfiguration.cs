using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APS8_CSHARP_API.Domain.Helpers;
using APS8_CSHARP_API.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace APS8_CSHARP_API.Api.Configurations
{
    public static class DataBaseConfiguration
    {
        public static void AddDataBaseConfiguration(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Constants.ConnectionString));
        }
    }
}