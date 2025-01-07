using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.Orders.OrderDtos;

namespace TajMaster.Application.UseCases.Orders.Queries.GetOrdersByUser;

public record GetOrdersByUserIdQuery(int UserId) : IQuery<IEnumerable<OrderDetailDto>>;