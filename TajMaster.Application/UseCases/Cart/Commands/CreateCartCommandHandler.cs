using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;

namespace TajMaster.Application.UseCases.Cart.Commands;

public class CreateCartCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateCartCommand, Guid>
{
    public async Task<Guid> Handle(CreateCartCommand command, CancellationToken cancellationToken)
    {
        var activeStatus = await context.CartStatuses
            .AsNoTracking()
            .FirstOrDefaultAsync(cs => cs.Name == "Active", cancellationToken);

        if (activeStatus == null)
            throw new InvalidOperationException("Cart status 'Active' not found.");
        
        var newCart = new Domain.Entities.Cart
        {
            UserId = command.UserId,
            CartStatusId = activeStatus.Id, // Reference by foreign key
        };
        
        await context.Carts.AddAsync(newCart, cancellationToken);
        
        await context.SaveChangesAsync(cancellationToken);

        return newCart.Id;
    }
}