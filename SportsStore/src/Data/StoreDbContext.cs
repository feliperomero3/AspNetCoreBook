using Microsoft.EntityFrameworkCore;
using SportsStore.Entities;

namespace SportsStore.Data;

public class StoreDbContext : DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>(builder =>
        {
            builder.ToTable("Products").HasKey(p => p.ProductId);
            builder.Property(p => p.ProductId).HasColumnType("bigint");
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(250).IsRequired();
            builder.Property(p => p.Price).HasColumnType("decimal(8, 2)");
            builder.Property(p => p.Category).HasMaxLength(50).IsRequired();
        });
    }
}
