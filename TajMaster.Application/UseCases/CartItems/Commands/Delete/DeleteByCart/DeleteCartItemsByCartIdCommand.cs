using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.CartItems.Commands.Delete.DeleteByCart;

public record DeleteCartItemsByCartIdCommand(Guid CartId) : IQuery<bool>;