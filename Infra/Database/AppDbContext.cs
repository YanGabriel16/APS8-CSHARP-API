using APS8_CSHARP_API.Domain.Entidades;
using APS8_CSHARP_API.Domain.Helpers;
using Microsoft.EntityFrameworkCore;

namespace APS8_CSHARP_API.Infra.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Local> Locais { get; set; }
        public DbSet<LocalInformacoes> LocalInformacoes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected AppDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Constants.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Local>()
                .Property(p => p.Latitude)
                .HasColumnType("decimal(18, 7)");

            modelBuilder.Entity<Local>()
                .Property(p => p.Longitude)
                .HasColumnType("decimal(18, 7)");

            base.OnModelCreating(modelBuilder);
        }
    }
}