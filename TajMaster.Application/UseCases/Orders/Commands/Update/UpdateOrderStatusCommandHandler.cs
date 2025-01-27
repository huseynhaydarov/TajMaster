using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.Orders.Commands.Update;

public class UpdateOrderStatusCommandHandler(
    IApplicationDbContext context) 
    : IRequestHandler<UpdateOrderStatusCommand, bool>
{
    public async Task<bool> Handle(UpdateOrderStatusCommand command, CancellationToken cancellationToken)
    {
       
        var order = await context.Orders
            .Include(o => o.OrderStatus)
            .FirstOrDefaultAsync(o => o.Id == command.OrderId, cancellationToken);
        
        if (order == null)
        {
            throw new NotFoundException("Order not found.");
        }
        
        var newStatus = await context.OrderStatuses
            .FirstOrDefaultAsync(os => os.Id == command.OrderStatusId, cancellationToken);
        
        if (newStatus == null)
        {
            throw new NotFoundException("Order status not found.");
        }
        
        order.OrderStatusId = command.OrderStatusId;
        
        context.Orders.Update(order);
        
        await context.SaveChangesAsync(cancellationToken);

        return true;
    }
}