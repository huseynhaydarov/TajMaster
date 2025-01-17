using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Orders.OrderDtos;
using TajMaster.Application.UseCases.Orders.OrderExtensions;

namespace TajMaster.Application.UseCases.Orders.Queries.GetOrdersByUser;

public class GetOrdersByUserQueryHandler(
    IApplicationDbContext context)
    : IQueryHandler<GetOrdersByUserIdQuery, IEnumerable<OrderDetailDto>>
{
    public async Task<IEnumerable<OrderDetailDto>> Handle(GetOrdersByUserIdQuery query,
        CancellationToken cancellationToken)
    {
        var orders = await context.Orders
            .AsNoTracking()
            .Include(r => r.User)
            .Where(r => r.UserId == query.UserId)
            .ToListAsync(cancellationToken);

        if (!orders.Any())
        {
            throw new NotFoundException($"No orders found for user with ID: {query.UserId}");
        }

        return orders.ToOrderDetailDtoList();
    }
}