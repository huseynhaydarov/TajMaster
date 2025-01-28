using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.UseCases.OrderStatuses.OrderStatusDtos;

namespace TajMaster.Application.UseCases.OrderStatuses.Queries.GetOrderStatusByName;

public class GetOrderStatusByNameQueryHandler(
    IApplicationDbContext context)
    : IQueryHandler<GetOrderStatusByNameQuery, OrderStatusDto>
{
    public async Task<OrderStatusDto> Handle(GetOrderStatusByNameQuery request, CancellationToken cancellationToken)
    {
        var orderStatus = await context.OrderStatuses
            .AsNoTracking()
            .FirstOrDefaultAsync(cs => cs.Name == request.Name, cancellationToken);

        return (orderStatus == null
            ? null
            : new OrderStatusDto(orderStatus.Id, orderStatus.Name, orderStatus.Code))!;
    }
}