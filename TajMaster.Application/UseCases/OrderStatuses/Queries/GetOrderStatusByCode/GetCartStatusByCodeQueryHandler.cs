using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.UseCases.OrderStatuses.OrderStatusDtos;

namespace TajMaster.Application.UseCases.OrderStatuses.Queries.GetOrderStatusByCode;

public class GetOrderStatusByCodeQueryHandler(
    IApplicationDbContext context) 
    : IQueryHandler<GetOrderStatusByCodeQuery, OrderStatusDto>
{
    public async Task<OrderStatusDto> Handle(GetOrderStatusByCodeQuery request, CancellationToken cancellationToken)
    {
        var orderStatus = await context.OrderStatuses
            .AsNoTracking()
            .FirstOrDefaultAsync(cs => cs.Code == request.Code, cancellationToken);

        return (orderStatus == null
            ? null
            : new OrderStatusDto(orderStatus.Id, orderStatus.Name, orderStatus.Code))!;
    }
}