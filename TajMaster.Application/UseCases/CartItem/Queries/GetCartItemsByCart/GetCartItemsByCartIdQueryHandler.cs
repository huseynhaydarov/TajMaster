using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.CartItem.CartItemDTos;

namespace TajMaster.Application.UseCases.CartItem.Queries.GetCartItemsByCart;

public class GetCartItemsByCartIdQueryHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<GetCartItemsByCartIdQuery, IEnumerable<CartItemDto>>
{
    public async Task<IEnumerable<CartItemDto>> Handle(GetCartItemsByCartIdQuery request, CancellationToken cancellationToken)
    {
        var cartItems = await unitOfWork.CartItemRepository.GetCartItemsByCartIdAsync(request.CartId);

        if (cartItems == null || !cartItems.Any())
            throw new NotFoundException($"No cart items found for cart with ID: {request.CartId}");
        
        return cartItems.Select(cartItem => new CartItemDto(
            cartItem.CartId,
            cartItem.Service.Title,
            cartItem.ServiceId,
            cartItem.Price
        )).ToList();
    }
}
