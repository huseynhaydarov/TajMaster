using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.Craftsmen.Commands.Update.UpdateCraftsman;

public class UpdateCraftsmanCommandHandler(
    IApplicationDbContext context, 
    IMapper mapper)
    : IRequestHandler<UpdateCraftsmanCommand, bool>
{
    public async Task<bool> Handle(UpdateCraftsmanCommand command, CancellationToken cancellationToken)
    {
        var craftsman = await context.Craftsmen.FirstOrDefaultAsync(cr => cr.Id == command.CraftsmanId, cancellationToken);

        if (craftsman == null)
        {
            throw new NotFoundException($"Craftsman with ID {command.CraftsmanId} not found.");
        }

        mapper.Map(command, craftsman);

        context.Craftsmen.Update(craftsman);

        await context.SaveChangesAsync(cancellationToken);

        return await Task.FromResult(true);
    }
}