using AutoMapper;
using MediatR;
using TajMaster.Application.Common.Interfaces.Data;

namespace TajMaster.Application.UseCases.CartStatus.Command.Update;

public class UpdateCartStatusCommandHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<UpdateCartStatusCommand, bool>
{
    public async Task<bool> Handle(UpdateCartStatusCommand command, CancellationToken cancellationToken)
    {
        var cartStatus = await context.CartStatuses.FindAsync(command.CartStatusId, cancellationToken);

        if (cartStatus == null)
            return false;
        
        mapper.Map(command, cartStatus);
        
        await context.SaveChangesAsync(cancellationToken);

        return true; 
    }
}