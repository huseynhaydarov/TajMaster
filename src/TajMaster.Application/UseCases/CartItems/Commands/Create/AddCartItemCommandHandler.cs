using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Domain.Entities;
using TajMaster.Domain.Enumerations;

namespace TajMaster.Application.UseCases.CartItems.Commands.Create;

public class AddCartItemCommandHandler(
    IApplicationDbContext context)
    : ICommandHandler<AddCartItemCommand, Guid>
{
    public async Task<Guid> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
    {
        var cart = await context.Carts
            .Include(c => c.CartStatus)
            .Include(c => c.CartItems)
            .FirstOrDefaultAsync(c => c.Id == request.CartId, cancellationToken);
        
        if (cart == null)
        {
            throw new NotFoundException("Cart not found.");
        }
       
        var activeStatus = await context.CartStatuses
            .FirstOrDefaultAsync(cs => cs.Id == CartStatusEnum.Active.Id, cancellationToken);
        
        if (cart.CartStatus.Id == CartStatusEnum.Archived.Id)
        {
            cart.CartStatus = activeStatus ?? throw new NullReferenceException();
        }
        
        var service = await context.Services
            .FirstOrDefaultAsync(s => s.Id == request.ServiceId, cancellationToken);

        if (service == null)
        {
            throw new NotFoundException("Service not found.");
        }
        
        var existingItem = cart.CartItems
            .FirstOrDefault(ci => ci.ServiceId == request.ServiceId);

        if (existingItem != null)
        {
            existingItem.Quantity += 1;
            existingItem.Price = service.BasePrice * existingItem.Quantity;

            context.CartItems.Update(existingItem);
        }
        else
        {
            var newCartItem = new CartItem
            {
                CartId = cart.Id,
                ServiceId = request.ServiceId,
                Quantity = 1,
                Price = service.BasePrice
            };

            await context.CartItems.AddAsync(newCartItem, cancellationToken);
        }
        
        if (cart.CartStatus.Id  != CartStatusEnum.Active.Id)
        {
            cart.CartStatus = activeStatus ?? throw new NullReferenceException();
        }
        
        context.Carts.Update(cart); 
        
        await context.SaveChangesAsync(cancellationToken);
        
        return cart.Id;
    }
}

