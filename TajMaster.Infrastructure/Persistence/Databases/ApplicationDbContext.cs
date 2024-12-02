using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TajMaster.Domain.Abstractions;
using TajMaster.Domain.Entities;
using TajMaster.Domain.Enums;

namespace TajMaster.Infrastructure.Persistence.Databases;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Craftsman> Craftsmen { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<BaseEntity>();
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
        
    }
}