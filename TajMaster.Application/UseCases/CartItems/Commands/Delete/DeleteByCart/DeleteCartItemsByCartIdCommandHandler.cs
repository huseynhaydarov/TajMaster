using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;

namespace TajMaster.Application.UseCases.CartItem.Commands.Delete.DeleteByCart;

public class DeleteCartItemsByCartIdCommandHandler(
    IApplicationDbContext context)
    : IRequestHandler<DeleteCartItemsByCartIdCommand, bool>
{
    public async Task<bool> Handle(DeleteCartItemsByCartIdCommand request, CancellationToken cancellationToken)
    {
        var cartItems = await context.CartItems
            .Where(ci => ci.CartId == request.CartId)
            .ToListAsync(cancellationToken);
        
        context.CartItems.RemoveRange(cartItems);
        
        await context.SaveChangesAsync(cancellationToken);

        return await Task.FromResult(true);
    }
}