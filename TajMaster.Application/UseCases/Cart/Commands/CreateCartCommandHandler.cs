using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;

namespace TajMaster.Application.UseCases.Cart.Commands;

public class CreateCartCommandHandler(
    IApplicationDbContext context) 
    : IRequestHandler<CreateCartCommand, Guid>
{
    public async Task<Guid> Handle(CreateCartCommand command, CancellationToken cancellationToken)
    {
        var cartStatus = await context.CartStatuses
            .AsNoTracking()
            .FirstOrDefaultAsync(cs => cs.Name == "Active", cancellationToken);

        if (cartStatus == null)
        {
            throw new InvalidOperationException("Cart status 'Active' not found.");
        }
        
        var newCart = new Domain.Entities.Cart
        {
            UserId = command.UserId,
            CartStatusId = cartStatus.Id, // Reference by foreign key CartStatusEnum.Created.Value
        };
        
        await context.Carts.AddAsync(newCart, cancellationToken);
        
        await context.SaveChangesAsync(cancellationToken);

        return newCart.Id;
    }
}