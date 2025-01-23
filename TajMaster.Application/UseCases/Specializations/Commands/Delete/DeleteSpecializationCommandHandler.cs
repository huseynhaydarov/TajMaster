using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Specializations.Commands.Delete;

public class DeleteSpecializationCommandHandler(IApplicationDbContext context)
    : IRequestHandler<DeleteSpecializationCommand, bool>
{
    public async Task<bool> Handle(DeleteSpecializationCommand command, CancellationToken cancellationToken)
    {
        var specialization = await context.Specializations
            .FirstOrDefaultAsync(s => s.Id == command.SpecializationId, cancellationToken);

        if (specialization == null)
        {
            throw new NotFoundException($"Specialization with ID {command.SpecializationId} was not found");
        }

        if (specialization.Craftsmen != null && specialization.Craftsmen.Any())
        {
            throw new InvalidOperationException("This specialization is in use by craftsmen.");
        }

        context.Specializations.Remove(specialization);

        await context.SaveChangesAsync(cancellationToken);

        return await Task.FromResult(true);
    }
}