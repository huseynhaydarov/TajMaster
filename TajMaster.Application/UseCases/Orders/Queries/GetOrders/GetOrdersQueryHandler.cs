using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.Orders.OrderDtos;
using TajMaster.Application.UseCases.Orders.OrderExtensions;

namespace TajMaster.Application.UseCases.Orders.Queries.GetOrders;

public class GetOrdersQueryHandler(
    IApplicationDbContext context)
    : IQueryHandler<GetOrdersQuery, PaginatedResult<OrderSummaryDto>>
{
    public async Task<PaginatedResult<OrderSummaryDto>> Handle(GetOrdersQuery query,
        CancellationToken cancellationToken)
    {
        var pagingParams = query.PagingParameters;

        var request = context.Orders
            .AsNoTracking()
            .Include(o => o.OrderItems)
            .Include(o => o.Reviews)
            .AsQueryable();

        request = pagingParams.OrderByDescending == true
            ? request.OrderByDescending(u => u.Id)
            : request.OrderBy(u => u.Id);

        var totalCount = await request.CountAsync(cancellationToken);
        
        var paginatedOrders = await request
            .Skip(pagingParams.Skip)
            .Take(pagingParams.Take)
            .ToListAsync(cancellationToken);

        var orderDto = paginatedOrders.ToOrderSummaryDtoList();
        
        return new PaginatedResult<OrderSummaryDto>(
            (int)pagingParams.PageNumber!,
            (int)pagingParams.PageSize!,
            totalCount,
            orderDto
        );
    }
}