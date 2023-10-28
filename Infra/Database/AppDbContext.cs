using APS8_CSHARP_API.Domain.Entidades;
using APS8_CSHARP_API.Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace APS8_CSHARP_API.Infra.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Local> Locais { get; set; }
        public DbSet<LocalInformacoes> LocalInformacoes { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.LocalMap();
            base.OnModelCreating(modelBuilder);
        }
    }
}