using Microsoft.EntityFrameworkCore;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.Common.Interfaces.Data;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<Service> Services { get; }
    DbSet<Review> Reviews { get; }
    DbSet<Order> Orders { get; }
    DbSet<Craftsman> Craftsmen { get; }
    DbSet<Category> Categories { get; }
    DbSet<OrderItem> OrderItems { get; }
    DbSet<Cart> Carts { get; }
    DbSet<CartStatusEntity> CartStatuses { get; }
    DbSet<CartItem> CartItems { get; }
    
    DbSet<Specialization> Specializations { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}