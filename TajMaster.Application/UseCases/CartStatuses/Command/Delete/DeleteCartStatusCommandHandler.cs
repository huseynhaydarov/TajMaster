using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.CartStatuses.Command.Delete;

public class DeleteCartStatusCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteCartStatusCommand, bool>
{
    public async Task<bool> Handle(DeleteCartStatusCommand command, CancellationToken cancellationToken)
    {
        var cartStatus = await context.CartStatuses
            .FirstOrDefaultAsync(cs => cs.Id == command.Id, cancellationToken);

        if (cartStatus == null)
        {
            throw new NotFoundException("No cart status found");
        }
        
        context.CartStatuses.Remove(cartStatus);
        
        await context.SaveChangesAsync(cancellationToken);

        return await Task.FromResult(true);
    }
}