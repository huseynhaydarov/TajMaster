using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.CartItems.Commands.Create;

public class AddCartItemCommandHandler(
    IApplicationDbContext context)
    : IRequestHandler<AddCartItemCommand, Guid>
{
    public async Task<Guid> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
    {
        // Fetch the cart
        var cart = await context.Carts
            .Include(c => c.CartItems)
            .FirstOrDefaultAsync(c => c.Id == request.CartId, cancellationToken);

        if (cart == null) throw new NotFoundException("Cart not found.");

        // Fetch the service to get the price
        var service = await context.Services
            .FirstOrDefaultAsync(s => s.Id == request.ServiceId, cancellationToken);

        if (service == null) throw new NotFoundException("Service not found.");

        // Check if the cart item already exists
        var existingItem = cart.CartItems
            .FirstOrDefault(ci => ci.ServiceId == request.ServiceId);

        if (existingItem != null)
        {
            // Update the existing item's quantity and total price
            existingItem.Quantity += 1;
            existingItem.Price = service.BasePrice * existingItem.Quantity;

            context.CartItems.Update(existingItem);
        }
        else
        {
            // Add a new cart item with the service's BasePrice
            var newCartItem = new Domain.Entities.CartItem
            {
                CartId = request.CartId,
                ServiceId = request.ServiceId,
                Quantity = 1,
                Price = service.BasePrice // Use the BasePrice of the service
            };
            await context.CartItems.AddAsync(newCartItem, cancellationToken);
        }

        await context.SaveChangesAsync(cancellationToken);

        return request.CartId;
    }
}