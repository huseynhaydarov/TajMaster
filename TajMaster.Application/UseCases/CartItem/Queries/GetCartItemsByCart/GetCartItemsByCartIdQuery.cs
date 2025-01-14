using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.CartItem.CartItemDTos;

namespace TajMaster.Application.UseCases.CartItem.Queries.GetCartItemsByCart;

public record GetCartItemsByCartIdQuery(Guid CartId) : IQuery<IEnumerable<CartItemDto>>;