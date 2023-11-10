using APS8_CSHARP_API.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace APS8_CSHARP_API.Infra.Mapping
{
    public static class LocalMapping
    {
        public static void LocalMap(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Local>()
                .Property(x => x.Latitude)
                .HasPrecision(18, 7);

            modelBuilder.Entity<Local>()
                .Property(x => x.Longitude)
                .HasPrecision(18, 7);
        }
    }
}