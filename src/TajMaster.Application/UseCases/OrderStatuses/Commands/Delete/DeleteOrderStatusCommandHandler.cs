using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.OrderStatuses.Commands.Delete;

public class DeleteOrderStatusCommandHandler(
    IApplicationDbContext context)
    : IRequestHandler<DeleteOrderStatusCommand, Unit>
{
    public async Task<Unit> Handle(DeleteOrderStatusCommand command, CancellationToken cancellationToken)
    {
        var orderStatus = await context.OrderStatuses
            .FirstOrDefaultAsync(cs => cs.Id == command.Id, cancellationToken);

        if (orderStatus == null)
        {
            throw new NotFoundException("No order status found");
        }

        context.OrderStatuses.Remove(orderStatus);

        await context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}