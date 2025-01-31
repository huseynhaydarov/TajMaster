using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Craftsmen.CraftsmanDtos;
using TajMaster.Application.UseCases.Craftsmen.CraftsmenExtension;

namespace TajMaster.Application.UseCases.Craftsmen.Queries.GetCraftsman;

public class GetCraftsmanByIdQueryHandler(
    IApplicationDbContext context)
    : IQueryHandler<GetCraftsmanByIdQuery, CraftsmanDto>
{
    public async Task<CraftsmanDto> Handle(GetCraftsmanByIdQuery query, CancellationToken cancellationToken)
    {
        var craftsman = await context.Craftsmen
            .Include(cr => cr.Specialization)
            .AsSplitQuery()
            .FirstOrDefaultAsync(cr => cr.Id == query.CraftsmanId, cancellationToken);

        if (craftsman == null)
        {
            throw new NotFoundException($"Craftsman with ID {query.CraftsmanId} not found.");
        }
        
        return craftsman.MapToCraftsmanDto();
    }
}