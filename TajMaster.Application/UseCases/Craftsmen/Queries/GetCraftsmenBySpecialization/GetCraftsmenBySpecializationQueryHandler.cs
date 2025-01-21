using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.UseCases.Craftsmen.CraftsmanDTos;
using TajMaster.Application.UseCases.Craftsmen.CraftsmenExtension;

namespace TajMaster.Application.UseCases.Craftsmen.Queries.GetCraftsmenBySpecialization;

public class GetCraftsmenBySpecializationQueryHandler(
    IApplicationDbContext context)
    : IQueryHandler<GetCraftsmenBySpecializationQuery, List<CraftsmanDto>>
{
    public async Task<List<CraftsmanDto>> Handle(GetCraftsmenBySpecializationQuery query,
        CancellationToken cancellationToken)
    {
        var craftsmen = await context.Craftsmen
            .AsNoTracking()
            .Where(cr => cr.Specialization.ToString() == query.Specialization)
            .ToListAsync(cancellationToken);

        if (!craftsmen.Any()) return new List<CraftsmanDto>();

        return craftsmen.ToCraftsmanDtos().ToList();
    }
}