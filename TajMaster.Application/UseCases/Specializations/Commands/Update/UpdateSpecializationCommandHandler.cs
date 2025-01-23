using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.Specializations.Commands.Update;

public class UpdateSpecializationCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdateSpecializationCommand, bool>
{
    public async Task<bool> Handle(UpdateSpecializationCommand command, CancellationToken cancellationToken)
    {
        var specialization = await context.Specializations
            .FirstOrDefaultAsync(s => s.Id == command.SpecializationId, cancellationToken);

        if (specialization == null)
        {
            throw new NotFoundException($"Specialization with ID {command.SpecializationId} not found");
        }

        context.Specializations.Update(specialization);

        await context.SaveChangesAsync(cancellationToken);

        return await Task.FromResult(true);
    }
}