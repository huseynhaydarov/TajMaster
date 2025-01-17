using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Orders.Create;

public class CreateOrderCommandHandler(
    IApplicationDbContext context) 
    : IRequestHandler<CreateOrderCommand, Guid>
{
    public async Task<Guid> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var cart = await context.Carts
            .Include(c => c.CartItems)
            .Include(c => c.CartStatus)
            .FirstOrDefaultAsync(c => c.UserId == command.UserId, cancellationToken);
        
        if (cart == null || !cart.CartItems.Any())
        {
            throw new NotFoundException("Cart is empty or not found.");
        }
        
        var completedStatus = await context.CartStatuses
            .FirstOrDefaultAsync(cs => cs.Name == "Completed", cancellationToken);
        var archivedStatus = await context.CartStatuses
            .FirstOrDefaultAsync(cs => cs.Name == "Archived", cancellationToken);
        
        if (completedStatus == null)
        {
            throw new NotFoundException("Cart status 'Completed' not found.");
        }

        if (archivedStatus == null)
        {
            throw new NotFoundException("Cart status 'Archived' not found.");
        }
        
        cart.CartStatus = completedStatus;
        
        var pendingStatus = await context.OrderStatuses
            .FirstOrDefaultAsync(os => os.Name == "Pending", cancellationToken);
        
        if (pendingStatus == null)
        {
            throw new NotFoundException("Order status 'Pending' not found.");
        }

        var order = new Order
        {
            UserId = command.UserId,
            Address = command.Address,
            AppointmentDate = command.AppointmentDate,
            CraftsmanId = command.CraftsmanId,
            OrderStatus = pendingStatus,
            TotalPrice = cart.Subtotal,
            OrderItems = cart.CartItems.Select(cartItem => new OrderItem
            {
                ServiceId = cartItem.ServiceId,
                Quantity = cartItem.Quantity,
                Price = cartItem.Price
            }).ToList()
        };
        
        cart.CartItems.Clear();
        
        cart.CartStatus = archivedStatus;
        
        context.Carts.Update(cart);
        context.Orders.Add(order);
        
        await context.SaveChangesAsync(cancellationToken);
        
        return order.Id;
    }
}
