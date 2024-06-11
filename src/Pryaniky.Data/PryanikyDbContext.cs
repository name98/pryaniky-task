using Microsoft.EntityFrameworkCore;
using Pryaniky.Domain;

namespace Pryaniky.Data;

public class PryanikyDbContext : DbContext
{
    public PryanikyDbContext(DbContextOptions options) : base(options)
    {
        base.Database.EnsureCreated();
    }

    public DbSet<Product> Products { get; set; } = null!;

    public DbSet<Order> Orders { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PryanikyDbContext).Assembly);
    }
}