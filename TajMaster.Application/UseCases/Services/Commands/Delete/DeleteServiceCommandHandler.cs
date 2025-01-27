using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.Services.Commands.Delete;

public class DeleteServiceCommandHandler(
    IApplicationDbContext context)
    : IRequestHandler<DeleteServiceCommand, Unit>
{
    public async Task<Unit> Handle(DeleteServiceCommand command, CancellationToken cancellationToken)
    {
        var service = await context.Services
            .FirstOrDefaultAsync(s => s.Id == command.ServiceId, cancellationToken);

        if (service == null)
        {
            throw new NotFoundException($"Service with ID {command.ServiceId} not found");
        }

        context.Services.Remove(service);

        await context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}