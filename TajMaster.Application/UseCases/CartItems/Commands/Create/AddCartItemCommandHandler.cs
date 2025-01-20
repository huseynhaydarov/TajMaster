using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.CartItem.Commands.Create;

public class AddCartItemCommandHandler(
    IApplicationDbContext context)
    : IRequestHandler<AddCartItemCommand, Guid>
{
    public async Task<Guid> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
    {
        var cart = await context.Carts
            .Include(c => c.CartItems)
            .FirstOrDefaultAsync(c => c.Id == request.CartId, cancellationToken);

        if (cart == null)
        {
            throw new NotFoundException("Cart not found.");
        }
        
        var existingItem = cart.CartItems.FirstOrDefault(ci => ci.ServiceId == request.ServiceId);
        
        if (existingItem != null)
        {
            existingItem.Quantity += 1;
            existingItem.Price = request.Price * existingItem.Quantity;

            context.CartItems.Update(existingItem);
        }
        else
        {
            var newCartItem = new Domain.Entities.CartItem
            {
                CartId = request.CartId,
                ServiceId = request.ServiceId,
                Price = request.Price,
                Quantity = 1
            };

            await context.CartItems.AddAsync(newCartItem, cancellationToken);
        }
        
        await context.SaveChangesAsync(cancellationToken);
        
        return request.CartId;
    }
}
