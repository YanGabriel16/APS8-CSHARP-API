using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APS8_CSHARP_API.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace APS8_CSHARP_API.Api.Configurations
{
    public static class DataBaseConfiguration
    {
        public static void AddDataBaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=APS8-db;Integrated Security=True"));
        }
    }
}