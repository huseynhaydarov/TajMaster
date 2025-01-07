using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Orders.OrderDtos;
using TajMaster.Application.UseCases.Orders.OrderExtensions;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Orders.Queries.GetOrdersByUser;

public class GetOrdersByUserQueryHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<GetOrdersByUserIdQuery, IEnumerable<OrderDetailDto>>
{
    public async Task<IEnumerable<OrderDetailDto>> Handle(GetOrdersByUserIdQuery request,
        CancellationToken cancellationToken)
    {
        var orders = await unitOfWork.OrderRepository.GetOrdersByUserIdAsNoTracking(request.UserId, cancellationToken);

        var enumerable = orders as Order[] ?? orders.ToArray();
        if (orders == null || !enumerable.Any())
            throw new NotFoundException($"No orders found for user with ID: {request.UserId}");

        return enumerable.Select(order => order.MapToOrder());
    }
}