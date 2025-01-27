using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Domain.Entities;
using TajMaster.Domain.Enumerations;

namespace TajMaster.Application.UseCases.Orders.Commands.Create;

public class CreateOrderCommandHandler(
    IApplicationDbContext context)
    : IRequestHandler<CreateOrderCommand, Guid>
{
    public async Task<Guid> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var cart = await context.Carts
            .Include(c => c.CartItems)
            .ThenInclude(s => s.Service)
            .Include(c => c.CartStatus)
            .FirstOrDefaultAsync(c => c.UserId == command.UserId, cancellationToken);
        
        
        var craftsmanId = cart!.CartItems.FirstOrDefault()?.Service?.CraftsmanId;

        if (cart == null || !cart.CartItems.Any())
        {
            throw new NotFoundException("Cart is empty or not found.");
        }

        var archivedStatus = await context.CartStatuses
            .FirstOrDefaultAsync(cs => cs.Name == CartStatusEnum.Archived.Name, cancellationToken);

        if (archivedStatus == null)
        {
            throw new NotFoundException("Cart status 'Archived' not found.");
        }

        var pendingStatus = await context.OrderStatuses
            .FirstOrDefaultAsync(os => os.Name == OrderStatusEnum.Pending.Name, cancellationToken);

        if (pendingStatus == null)
        {
            throw new NotFoundException("Order status 'Pending' not found.");
        }

        var order = new Order
        {
            UserId = command.UserId,
            CraftsmanId = (Guid)craftsmanId!,
            Address = command.Address,
            AppointmentDate = command.AppointmentDate,
            OrderStatus = pendingStatus,
            TotalPrice = cart.Subtotal,
            OrderItems = cart.CartItems.Select(cartItem => new OrderItem
            {
                ServiceId = cartItem.ServiceId,
                Quantity = cartItem.Quantity,
                Price = cartItem.Price
            }).ToList()
        };

        context.CartItems.RemoveRange(cart.CartItems);
        
        cart.CartStatus = archivedStatus;

        context.Carts.Update(cart);
       
        context.Orders.Add(order);

        await context.SaveChangesAsync(cancellationToken);

        return order.Id;
    }
}