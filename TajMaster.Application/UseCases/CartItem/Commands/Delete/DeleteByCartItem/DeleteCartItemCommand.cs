using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.CartItem.Commands.Delete.DeleteByCartItem;

public record DeleteCartItemCommand(Guid CartItemId) : ICommand<bool>;