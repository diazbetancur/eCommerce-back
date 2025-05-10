using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Data;

public class EcommerceDbContext : DbContext
{
    public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<ProductVariant> ProductVariants => Set<ProductVariant>();
    public DbSet<Cart> Carts => Set<Cart>();
    public DbSet<CartItem> CartItems => Set<CartItem>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Address> Addresses => Set<Address>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuraciones personalizadas (por ejemplo, relaciones obligatorias)
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<ProductVariant>()
            .HasOne(v => v.Product)
            .WithMany()
            .HasForeignKey(v => v.ProductId);

        modelBuilder.Entity<Cart>()
            .HasOne(c => c.Customer)
            .WithMany()
            .HasForeignKey(c => c.CustomerId);

        modelBuilder.Entity<CartItem>()
            .HasOne(i => i.Product)
            .WithMany()
            .HasForeignKey(i => i.ProductId);

        modelBuilder.Entity<CartItem>()
            .HasOne(i => i.Cart)
            .WithMany(c => c.Items)
            .HasForeignKey(i => i.CartId);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId);

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.Items)
            .HasForeignKey(oi => oi.OrderId);

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Product)
            .WithMany()
            .HasForeignKey(oi => oi.ProductId);

        modelBuilder.Entity<Address>()
            .HasOne(a => a.Customer)
            .WithMany(c => c.Addresses)
            .HasForeignKey(a => a.CustomerId);
    }
}