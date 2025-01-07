using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.CartItem.Commands.Delete.DeleteByCart;

public record DeleteCartItemsByCartIdCommand(int CartId) : IQuery<bool>;