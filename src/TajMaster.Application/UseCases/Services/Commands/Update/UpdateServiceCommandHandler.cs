using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.Services.Commands.Update;

public class UpdateServiceCommandHandler(
    IApplicationDbContext context,
    IMapper mapper)
    : IRequestHandler<UpdateServiceCommand, Unit>
{
    public async Task<Unit> Handle(UpdateServiceCommand command, CancellationToken cancellationToken)
    {
        var service = await context.Services
            .FirstOrDefaultAsync(s => s.Id == command.ServiceId, cancellationToken);

        if (service == null)
        {
            throw new NotFoundException($"Service with ID {command.ServiceId} was not found");
        }

        mapper.Map(command, service);

        context.Services.Update(service);

        await context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}