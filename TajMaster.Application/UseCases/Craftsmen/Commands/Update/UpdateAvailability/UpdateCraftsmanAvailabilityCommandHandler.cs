using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.Craftsmen.Commands.Update.UpdateAvailability;

public class UpdateCraftsmanAvailabilityCommandHandler(
    IApplicationDbContext context)
    : IRequestHandler<UpdateCraftsmanAvailabilityCommand, bool>
{
    public async Task<bool> Handle(UpdateCraftsmanAvailabilityCommand command, CancellationToken cancellationToken)
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

        return await Task.FromResult(true);
    }
}