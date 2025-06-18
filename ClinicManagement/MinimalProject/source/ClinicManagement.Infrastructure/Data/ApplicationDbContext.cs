using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ClinicManagement.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Infrastructure.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Report> Reports { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      // Configure relationships and constraints

      // User - Role relationship (Many-to-One)
      modelBuilder.Entity<User>()
          .HasOne(u => u.Role)
          .WithMany(r => r.Users)
          .HasForeignKey(u => u.RoleId);

      // Product - Category relationship (Many-to-One)
      modelBuilder.Entity<Product>()
          .HasOne(p => p.Category)
          .WithMany(c => c.Products)
          .HasForeignKey(p => p.CategoryId);

      // Product - ProductType relationship (Many-to-One)
      modelBuilder.Entity<Product>()
          .HasOne(p => p.ProductType)
          .WithMany(pt => pt.Products)
          .HasForeignKey(p => p.ProductTypeId);

      // Order - User relationship (Many-to-One)
      modelBuilder.Entity<Order>()
          .HasOne(o => o.User)
          .WithMany(u => u.Orders)
          .HasForeignKey(o => o.UserId);

      // OrderItem - Order relationship (Many-to-One)
      modelBuilder.Entity<OrderItem>()
          .HasOne(oi => oi.Order)
          .WithMany(o => o.OrderItems)
          .HasForeignKey(oi => oi.OrderId);

      // OrderItem - Product relationship (Many-to-One)
      modelBuilder.Entity<OrderItem>()
          .HasOne(oi => oi.Product)
          .WithMany(p => p.OrderItems)
          .HasForeignKey(oi => oi.ProductId);

      // Payment - Order relationship (One-to-One)
      modelBuilder.Entity<Payment>()
          .HasOne(p => p.Order)
          .WithOne(o => o.Payment)
          .HasForeignKey<Payment>(p => p.OrderId);

      // Report - User relationship (Many-to-One)
      modelBuilder.Entity<Report>()
          .HasOne(r => r.GeneratedBy)
          .WithMany(u => u.Reports)
          .HasForeignKey(r => r.GeneratedById);
    }

    public override int SaveChanges()
    {
      UpdateTimestamps();
      return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
      UpdateTimestamps();
      return await base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateTimestamps()
    {
      var entries = ChangeTracker
          .Entries()
          .Where(e => e.Entity is BaseEntity && (
              e.State == EntityState.Added || e.State == EntityState.Modified));

      foreach (var entityEntry in entries)
      {
        if (entityEntry.State == EntityState.Added)
        {
          ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.Now;
        }

          ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.Now;
      }
    }
  }
}
