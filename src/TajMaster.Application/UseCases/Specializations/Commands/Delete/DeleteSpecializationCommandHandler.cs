using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.Specializations.Commands.Delete;

public class DeleteSpecializationCommandHandler(
    IApplicationDbContext context,
    IDistributedCache cacheService)
    : IRequestHandler<DeleteSpecializationCommand, Unit>
{
    public async Task<Unit> Handle(DeleteSpecializationCommand command, CancellationToken cancellationToken)
    {
        var cacheKey = $"Specialization_{command.SpecializationId}";
        
        var specialization = await context.Specializations
            .FirstOrDefaultAsync(s => s.Id == command.SpecializationId, cancellationToken);

        if (specialization == null)
        {
            throw new NotFoundException($"Specialization with ID {command.SpecializationId} was not found");
        }

        if (specialization.Craftsmen != null && specialization.Craftsmen.Count != 0)
        {
            throw new InvalidOperationException("This specialization is in use by craftsmen.");
        }

        context.Specializations.Remove(specialization);
        
        await cacheService.RemoveAsync(cacheKey, cancellationToken);

        await context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}