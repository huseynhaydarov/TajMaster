using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.UseCases.Craftsmen.CraftsmanDtos;
using TajMaster.Application.UseCases.Craftsmen.CraftsmenExtension;

namespace TajMaster.Application.UseCases.Craftsmen.Queries.GetCraftsmenBySpecialization;

public class GetCraftsmenBySpecializationQueryHandler(
    IApplicationDbContext context)
    : IQueryHandler<GetCraftsmenBySpecializationQuery, IEnumerable<CraftsmanDto>>
{
    public async Task<IEnumerable<CraftsmanDto>> Handle(GetCraftsmenBySpecializationQuery query,
        CancellationToken cancellationToken)
    {
        var craftsmen = await context.Craftsmen
            .AsNoTracking()
            .Include(c => c.Specialization)
            .AsSingleQuery()
            .Where(cr => cr.Specialization.Name.ToLower() == query.Specialization.ToLower())
            .ToListAsync(cancellationToken);

        if (!craftsmen.Any())
        {
            return [];
        }
        
        return craftsmen.ToCraftsmanDtos();
    }
}