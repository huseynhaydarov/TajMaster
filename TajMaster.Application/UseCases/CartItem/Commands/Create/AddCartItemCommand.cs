using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.CartItem.Commands.Create;

public record AddCartItemCommand(
    int CartId,
    int ServiceId,
    decimal Price) : ICommand<int>;