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
        var craftsman = await context.Craftsmen
            .Include(cr => cr.Specialization) 
            .FirstOrDefaultAsync(cr => cr.Id == command.CraftsmanId, cancellationToken);

        if (craftsman == null)
        {
            throw new NotFoundException($"Craftsman with ID {command.CraftsmanId} not found.");
        }
        
        if (!string.IsNullOrEmpty(command.Specialization))
        {
            var specialization = await context.Specializations
                .FirstOrDefaultAsync(sp => sp.Name.ToLower() == command.Specialization.ToLower(), cancellationToken);
            
            if (specialization == null)
            {
                throw new NotFoundException($"Specialization with name {command.Specialization} not found.");
            }
            
            craftsman.SpecializationId = specialization.Id;
            craftsman.Specialization = specialization;        
        }
        
        mapper.Map(command, craftsman);
        
        context.Craftsmen.Update(craftsman);
        
        await context.SaveChangesAsync(cancellationToken);

        return await Task.FromResult(true);
    }
}