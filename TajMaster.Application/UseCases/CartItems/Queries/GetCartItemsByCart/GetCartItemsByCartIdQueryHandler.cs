using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.CartItem.CartItemDTos;

namespace TajMaster.Application.UseCases.CartItem.Queries.GetCartItemsByCart;

public class GetCartItemsByCartIdQueryHandler(
    IApplicationDbContext context)
    : IRequestHandler<GetCartItemsByCartIdQuery, IEnumerable<CartItemDto>>
{
    public async Task<IEnumerable<CartItemDto>> Handle(GetCartItemsByCartIdQuery request,
        CancellationToken cancellationToken)
    {
        var cartItems = await context.CartItems
            .Include(ci => ci.Service)
            .Where(ci => ci.CartId == request.CartId)
            .ToListAsync(cancellationToken);
        
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