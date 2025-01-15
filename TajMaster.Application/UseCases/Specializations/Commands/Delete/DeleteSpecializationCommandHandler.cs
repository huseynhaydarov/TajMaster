using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Specializations.Commands.Delete;

public class DeleteSpecializationCommandHandler(IApplicationDbContext context)
    : IRequestHandler<DeleteSpecializationCommand, bool>
{
    public async Task<bool> Handle(DeleteSpecializationCommand request, CancellationToken cancellationToken)
    {
        var specialization = await context.Specializations
            .FirstOrDefaultAsync(s => s.Id == request.SpecializationId, cancellationToken);

        if (specialization == null)
        {
            throw new NotFoundException(nameof(Specialization));
        }
        
        if (specialization.Craftsmen != null && specialization.Craftsmen.Any())
        {
            throw new InvalidOperationException("This specialization cannot be deleted because it is in use by craftsmen.");
        }
        
        context.Specializations.Remove(specialization);
        await context.SaveChangesAsync(cancellationToken);
        
        return true;
    }
}