using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.CartItems.Commands.Create;

public record AddCartItemCommand(
    Guid CartId,
    Guid ServiceId) : ICommand<Guid>;