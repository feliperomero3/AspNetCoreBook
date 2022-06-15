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

        modelBuilder.Entity<CartLine>(builder =>
        {
            builder.ToTable("CartLine").HasKey(l => l.CartLineId);
            builder.Property(l => l.CartLineId).HasColumnType("bigint");
            builder.Property(l => l.Quantity).HasColumnType("int").IsRequired();
        });

        modelBuilder.Entity<Order>(builder =>
        {
            builder.ToTable("Orders").HasKey(o => o.OrderId);
            builder.Property(o => o.OrderId).HasColumnType("bigint");
            builder.Property(o => o.Name).HasMaxLength(50).IsRequired();
            builder.Property(o => o.City).HasMaxLength(50).IsRequired();
            builder.Property(o => o.State).HasMaxLength(50).IsRequired();
            builder.Property(o => o.Zip).HasMaxLength(10).IsRequired();
            builder.Property(o => o.Country).HasMaxLength(50).IsRequired();
        });
    }
}
