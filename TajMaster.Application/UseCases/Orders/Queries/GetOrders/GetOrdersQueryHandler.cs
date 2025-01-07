using AutoMapper;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.Orders.OrderDtos;
using TajMaster.Application.UseCases.Orders.OrderExtensions;

namespace TajMaster.Application.UseCases.Orders.Queries.GetOrders;

public class GetOrdersQueryHandler(IUnitOfWork unitOfWork) : IQueryHandler<GetOrdersQuery, PaginatedResult<OrderSummaryDto>>
{
    public async Task<PaginatedResult<OrderSummaryDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var pagingParams = request.PagingParameters;

        var paginatedOrders = await unitOfWork.OrderRepository.GetAllAsync(pagingParams, cancellationToken);

        var totalCount = paginatedOrders.Count();

        var orderDto =  paginatedOrders.ToOrderSummaryDtoList();;
        
        var paginatedResult = new PaginatedResult<OrderSummaryDto>(
            (int)pagingParams.PageNumber!,
            (int)pagingParams.PageSize!,
            totalCount,
            orderDto
        );

        return paginatedResult;
    }
}