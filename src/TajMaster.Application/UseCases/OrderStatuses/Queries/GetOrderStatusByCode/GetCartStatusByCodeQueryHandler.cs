using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
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

        if (orderStatus == null)
        {
            throw new NotFoundException("OrderStatus not found");
        }
        
        return new OrderStatusDto(
            StatusId: orderStatus.Id,
            Code: orderStatus.Code,
            Name: orderStatus.Name);
    }
}