using TajMaster.Domain.Entities;

namespace TajMaster.Application.Common.Interfaces.Repositories;

public interface IOrderItemRepository : IRepository<OrderItem>
{
    Task<List<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId);
}