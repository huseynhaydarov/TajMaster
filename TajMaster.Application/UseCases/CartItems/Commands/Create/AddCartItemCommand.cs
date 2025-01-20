using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.CartItem.Commands.Create;

public record AddCartItemCommand(
    Guid CartId,
    Guid ServiceId,
    decimal Price) : ICommand<Guid>;