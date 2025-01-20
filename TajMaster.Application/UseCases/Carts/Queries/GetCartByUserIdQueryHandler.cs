using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Cart.CartDtos;
using TajMaster.Application.UseCases.Cart.CartExtensions;

namespace TajMaster.Application.UseCases.Cart.Queries;

public class GetCartByUserIdQueryHandler(
    IApplicationDbContext context)
    : IRequestHandler<GetCartByUserIdQuery, CartDto>
{
    public async Task<CartDto> Handle(GetCartByUserIdQuery request, CancellationToken cancellationToken)
    {
        
        var cart = await context.Carts
            .Include(c => c.CartItems)
            .ThenInclude(ci => ci.Service)
            .Include(c => c.CartStatus) 
            .FirstOrDefaultAsync(c => c.UserId == request.UserId 
                                      && c.CartStatus.Name == request.CartStatusName, cancellationToken); 
       
        if (cart == null)
        {
            throw new NotFoundException($"Cart for user ID {request.UserId} not found.");
        }
        
        return cart.ToCartDto();
    }
}