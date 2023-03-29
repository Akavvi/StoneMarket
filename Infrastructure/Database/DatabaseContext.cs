using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options) {}

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region default values
        
        modelBuilder.Entity<User>()
            .Property(u => u.IsActive)
            .HasDefaultValue(false);
        
        modelBuilder.Entity<User>()
            .Property(u => u.Rating)
            .HasDefaultValue(0.0f);

        modelBuilder.Entity<Product>()
            .Property(p => p.Description)
            .HasDefaultValue("Не указано");
        #endregion

        #region relations

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Owner);
        
        modelBuilder.Entity<User>()
            .HasMany(u => u.Products);

        #endregion

        base.OnModelCreating(modelBuilder);
    }
}