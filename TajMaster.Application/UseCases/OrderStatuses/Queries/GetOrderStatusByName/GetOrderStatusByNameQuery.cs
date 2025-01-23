using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.OrderStatuses.OrderStatusDtos;

namespace TajMaster.Application.UseCases.OrderStatuses.Queries.GetOrderStatusByName;

public record GetOrderStatusByNameQuery(string Name) : IQuery<OrderStatusDto>;