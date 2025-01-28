using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.CartItems.Commands.Delete.DeleteByCartItem;

public class DeleteCartItemCommandHandler(
    IApplicationDbContext context)
    : IRequestHandler<DeleteCartItemCommand, Unit>
{
    public async Task<Unit> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
    {
        var cartItem = await context.CartItems
            .FirstOrDefaultAsync(ci => ci.Id == request.CartItemId, cancellationToken);

        if (cartItem == null)
        {
            throw new NotFoundException($"Cart item with ID {request.CartItemId} not found.");
        }

        context.CartItems.Remove(cartItem);

        await context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}