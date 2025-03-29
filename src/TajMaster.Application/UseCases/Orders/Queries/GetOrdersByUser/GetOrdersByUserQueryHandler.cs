using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Interfaces.IdentityService;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Orders.OrderDtos;
using TajMaster.Application.UseCases.Orders.OrderExtensions;

namespace TajMaster.Application.UseCases.Orders.Queries.GetOrdersByUser;

public class GetOrdersByUserQueryHandler(
    IApplicationDbContext context,
    IAuthenticatedUserService authenticatedUserService)
    : IQueryHandler<GetOrdersByUserQuery, IEnumerable<OrderDetailDto>>
{
    public async Task<IEnumerable<OrderDetailDto>> Handle(GetOrdersByUserQuery query,
        CancellationToken cancellationToken)
    {
        var orders = await context.Orders
            .AsNoTracking()
            .Include(r => r.User)
            .Include(o => o.OrderStatus)
            .Include(r => r.OrderItems)
                .ThenInclude(s => s.Service)
            .AsNoTracking()
            .Where(r => r.UserId == authenticatedUserService.UserId)
            .ToListAsync(cancellationToken);

        if (!orders.Any())
        {
            throw new NotFoundException($"No orders found for user with ID: {authenticatedUserService.UserId}");
        }

        return orders.ToOrderDetailDtoList();
    }
}