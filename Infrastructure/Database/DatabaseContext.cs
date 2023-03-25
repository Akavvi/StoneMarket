using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options) {}

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Owner);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Products);
        
        base.OnModelCreating(modelBuilder);
    }
}