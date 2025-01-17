using AutoMapper;
using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Specializations.Commands.Create;

public class CreateSpecializationCommandHandler(
    IApplicationDbContext context, 
    IMapper mapper) 
    : IRequestHandler<CreateSpecializationCommand, Guid>
{
    public async Task<Guid> Handle(CreateSpecializationCommand command, CancellationToken cancellationToken)
    {
        var specialization = mapper.Map<Specialization>(command);
        
        context.Specializations.Add(specialization);
        
        await context.SaveChangesAsync(cancellationToken);
        
        return specialization.Id;
    }
}