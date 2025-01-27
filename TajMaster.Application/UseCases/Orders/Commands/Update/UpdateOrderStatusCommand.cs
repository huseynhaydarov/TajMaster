using MediatR;
using TajMaster.Domain.Entities;
using TajMaster.Domain.Enumerations;

namespace TajMaster.Application.UseCases.Orders.Commands.Update;

public record UpdateOrderStatusCommand(Guid OrderId, Guid OrderStatusId) : IRequest<bool>;
