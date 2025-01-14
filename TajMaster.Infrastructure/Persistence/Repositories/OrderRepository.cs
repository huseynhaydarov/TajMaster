using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Repositories;
using TajMaster.Application.Common.Pagination;
using TajMaster.Domain.Entities;
using TajMaster.Infrastructure.Persistence.Data;

namespace TajMaster.Infrastructure.Persistence.Repositories;

public class OrderRepository(ApplicationDbContext context) : Repository<Order>(context), IOrderRepository
{
    public async Task<Order> CreateAsync(Order order)
    {
        await context.Orders.AddAsync(order);
        await context.SaveChangesAsync();
        return order;
    }

    public async Task<IEnumerable<Order>> GetOrdersByUserIdAsNoTracking(Guid userId,
        CancellationToken cancellationToken = default)
    {
        return await context.Orders
            .AsNoTracking()
            .Include(review => review.User)
            .Where(review => review.UserId == userId)
            .ToListAsync(cancellationToken);
    }

    public override async Task<List<Order>> GetAllAsync(PagingParameters pagingParameters,
        CancellationToken cancellationToken = default)
    {
        var query = context.Orders
            .Include(o => o.OrderItems)
            .Include(o => o.Reviews).AsQueryable();

        if (pagingParameters.OrderByDescending == true)
            query = query.OrderByDescending(o => o.Id);
        else
            query = query.OrderBy(o => o.Id);
        return await query
            .Skip(pagingParameters.Skip)
            .Take(pagingParameters.Take)
            .ToListAsync(cancellationToken);
    }
}