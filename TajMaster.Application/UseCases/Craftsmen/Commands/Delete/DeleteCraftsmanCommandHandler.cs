using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.Craftsmen.Commands.Delete;

public class DeleteCraftsmanCommandHandler(
    IApplicationDbContext context)
    : IRequestHandler<DeleteCraftsmanCommand, bool>
{
    public async Task<bool> Handle(DeleteCraftsmanCommand command, CancellationToken cancellationToken)
    {
        var craftsman = await context.Craftsmen.FirstOrDefaultAsync(cr => cr.Id == command.CraftsmanId,
            cancellationToken);

        if (craftsman == null) throw new NotFoundException($"Craftsmen with ID {command.CraftsmanId} not found.");

        context.Craftsmen.Remove(craftsman);

        await context.SaveChangesAsync(cancellationToken);

        return await Task.FromResult(true);
    }
}