using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.CartItems.Commands.Delete.DeleteByCartItem;

public record DeleteCartItemCommand(Guid CartItemId) : ICommand<bool>;