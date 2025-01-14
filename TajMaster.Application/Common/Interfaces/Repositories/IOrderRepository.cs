using TajMaster.Domain.Entities;

namespace TajMaster.Application.Common.Interfaces.Repositories;

public interface IOrderRepository : IRepository<Order>
{
    Task<Order> CreateAsync(Order order);

    Task<IEnumerable<Order>> GetOrdersByUserIdAsNoTracking(Guid userId,
        CancellationToken cancellationToken = default);
}