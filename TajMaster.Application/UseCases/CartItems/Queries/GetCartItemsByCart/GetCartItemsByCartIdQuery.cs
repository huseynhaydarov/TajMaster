using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.CartItem.CartItemDTos;

namespace TajMaster.Application.UseCases.CartItems.Queries.GetCartItemsByCart;

public record GetCartItemsByCartIdQuery(Guid CartId) : IQuery<IEnumerable<CartItemDto>>;