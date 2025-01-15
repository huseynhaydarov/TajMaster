using MediatR;
using TajMaster.Application.Common.Interfaces.Data;

namespace TajMaster.Application.UseCases.CartStatus.Command.Delete;

public class DeleteCartStatusCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteCartStatusCommand, bool>
{
    public async Task<bool> Handle(DeleteCartStatusCommand request, CancellationToken cancellationToken)
    {
        var cartStatus = await context.CartStatuses.FindAsync(request.Id);

        if (cartStatus == null)
            return false;

        context.CartStatuses.Remove(cartStatus);
        
        await context.SaveChangesAsync(cancellationToken);

        return true;
    }
}