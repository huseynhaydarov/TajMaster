using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Repositories;
using TajMaster.Domain.Entities;
using TajMaster.Infrastructure.Persistence.Data;

namespace TajMaster.Infrastructure.Persistence.Repositories;

public class OrderItemRepository(ApplicationDbContext context) : Repository<OrderItem>(context), IOrderItemRepository
{
    public async Task<List<OrderItem>> GetOrderItemsByOrderIdAsync(Guid orderId)
    {
        return await context.OrderItems
            .Where(oi => oi.OrderId == orderId)
            .Include(oi => oi.Service)
            .ToListAsync();
    }
}