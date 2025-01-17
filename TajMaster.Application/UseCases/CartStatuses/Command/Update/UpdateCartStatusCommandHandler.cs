using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.CartStatuses.Command.Update;

public class UpdateCartStatusCommandHandler(
    IApplicationDbContext context,
    IMapper mapper) 
    : IRequestHandler<UpdateCartStatusCommand, bool>
{
    public async Task<bool> Handle(UpdateCartStatusCommand command, CancellationToken cancellationToken)
    {
        var cartStatus = await context.CartStatuses
            .FirstOrDefaultAsync(cs => cs.Id == command.CartStatusId, cancellationToken);

        if (cartStatus == null)
        {
            throw new NotFoundException("Cart status could not be found");
        }
        
        mapper.Map(command, cartStatus);
        
        await context.SaveChangesAsync(cancellationToken);

        return await Task.FromResult(true); 
    }
}