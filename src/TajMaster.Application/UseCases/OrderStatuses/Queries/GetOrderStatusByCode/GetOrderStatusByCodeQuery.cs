using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.OrderStatuses.OrderStatusDtos;

namespace TajMaster.Application.UseCases.OrderStatuses.Queries.GetOrderStatusByCode;

public record GetOrderStatusByCodeQuery(string Code) : IQuery<OrderStatusDto>;