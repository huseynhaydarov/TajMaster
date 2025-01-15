using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Specializations.Commands.Update;

public class UpdateSpecializationCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdateSpecializationCommand, bool>
{
    public async Task<bool> Handle(UpdateSpecializationCommand request, CancellationToken cancellationToken)
    {
        var specialization = await context.Specializations
            .FirstOrDefaultAsync(s => s.Id == request.SpecializationId, cancellationToken);

        if (specialization == null)
        {
            throw new NotFoundException(nameof(Specialization));
        }
        
        specialization.Name = request.Name ?? specialization.Name;
        specialization.Description = request.Description ?? specialization.Description;
        
        context.Specializations.Update(specialization);
        await context.SaveChangesAsync(cancellationToken);
        
        return true;
    }
}