using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Domain.Abstractions;
using TajMaster.Domain.Entities;

namespace TajMaster.Infrastructure.Persistence.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
    : DbContext(options), IApplicationDbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Service> Services => Set<Service>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<OrderStatus> OrderStatuses => Set<OrderStatus>();
    public DbSet<Craftsman> Craftsmen => Set<Craftsman>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Cart> Carts => Set<Cart>();
    public DbSet<CartStatus> CartStatuses => Set<CartStatus>();
    public DbSet<CartItem> CartItems => Set<CartItem>();
    public DbSet<CategoryService> CategoryServices => Set<CategoryService>();
    public DbSet<Specialization> Specializations => Set<Specialization>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<BaseEntity>();
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}