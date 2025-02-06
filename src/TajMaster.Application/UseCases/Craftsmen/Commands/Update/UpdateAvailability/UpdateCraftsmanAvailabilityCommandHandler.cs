using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.Craftsmen.Commands.Update.UpdateAvailability;

public class UpdateCraftsmanAvailabilityCommandHandler(
    IApplicationDbContext context)
    : ICommandHandler<UpdateCraftsmanAvailabilityCommand, Unit>
{
    public async Task<Unit> Handle(UpdateCraftsmanAvailabilityCommand command, CancellationToken cancellationToken)
    {
        var craftsmen = await context.Craftsmen
            .FirstOrDefaultAsync(cr => cr.Id == command.CraftsmanId, cancellationToken);

        if (craftsmen == null)
        {
            throw new NotFoundException($"Craftsman with ID {command.CraftsmanId} not found.");
        }

        craftsmen.IsAvialable = command.IsAvailable;

        context.Craftsmen.Update(craftsmen);

        await context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}