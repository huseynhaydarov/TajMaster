using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.CartItem.Commands.Delete.DeleteByCartItem;

public class DeleteCartItemCommandHandler(
    IApplicationDbContext context)
    : IRequestHandler<DeleteCartItemCommand, bool>
{
    public async Task<bool> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
    {
        var cartItem = await context.CartItems
            .FirstOrDefaultAsync(ci => ci.Id == request.CartItemId, cancellationToken);

        if (cartItem == null)
        {
            throw new NotFoundException($"Cart item with ID {request.CartItemId} not found.");
        }
        
        context.CartItems.Remove(cartItem);
        
        await context.SaveChangesAsync(cancellationToken);

        return await Task.FromResult(true); 
    }
}