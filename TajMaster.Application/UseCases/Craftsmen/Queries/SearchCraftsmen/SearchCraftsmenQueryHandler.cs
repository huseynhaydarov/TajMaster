using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.UseCases.Craftsmen.CraftsmanDTos;
using TajMaster.Application.UseCases.Craftsmen.CraftsmenExtension;

namespace TajMaster.Application.UseCases.Craftsmen.Queries.SearchCraftsmen;

public class SearchCraftsmenQueryHandler(IApplicationDbContext context)
    : IRequestHandler<SearchCraftsmenQuery, List<CraftsmanDto>>
{
    public async Task<List<CraftsmanDto>> Handle(SearchCraftsmenQuery request, CancellationToken cancellationToken)
    {
        var query = context.Craftsmen.AsNoTracking();

        if (!string.IsNullOrEmpty(request.Specialization))
            query = query.Where(c =>
                EF.Functions.Like(c.Specialization.ToString()!, $"%{request.Specialization}%"));

        if (request.Availability.HasValue) query = query.Where(c => c.IsAvialable == request.Availability.Value);

        if (request.ProfileVerified.HasValue)
            query = query.Where(c => c.ProfileVerified == request.ProfileVerified.Value);

        if (request.MinExperience.HasValue) query = query.Where(c => c.Experience >= request.MinExperience.Value);

        if (request.MinRating.HasValue) query = query.Where(c => c.Rating >= request.MinRating.Value);

        var result = await query.ToListAsync(cancellationToken);

        return result.ToCraftsmanDtos().ToList();
    }
}