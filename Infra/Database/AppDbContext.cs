using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APS8_CSHARP_API.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace APS8_CSHARP_API.Infra.Database
{
public class ApplicationDbContext : DbContext
{
    public DbSet<Local> Locais { get; set; }

    public string DbPath { get; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
}
}