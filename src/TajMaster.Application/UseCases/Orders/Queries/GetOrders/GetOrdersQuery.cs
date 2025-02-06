using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.Orders.OrderDtos;

namespace TajMaster.Application.UseCases.Orders.Queries.GetOrders;

public record GetOrdersQuery(PagingParameters PagingParameters) : IQuery<PaginatedResult<OrderSummaryDto>>;