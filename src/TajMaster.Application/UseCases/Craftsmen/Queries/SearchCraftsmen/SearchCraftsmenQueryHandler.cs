using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.UseCases.Craftsmen.CraftsmanDtos;
using TajMaster.Application.UseCases.Craftsmen.CraftsmenExtension;

namespace TajMaster.Application.UseCases.Craftsmen.Queries.SearchCraftsmen;

public class SearchCraftsmenQueryHandler(
    IApplicationDbContext context)
    : IQueryHandler<SearchCraftsmenQuery, IEnumerable<CraftsmanDto>>
{
    public async Task<IEnumerable<CraftsmanDto>> Handle(SearchCraftsmenQuery request, CancellationToken cancellationToken)
    {
        var craftsman = context.Craftsmen
            .Include(c => c.Specialization)
            .AsNoTracking();
        
        if (!string.IsNullOrWhiteSpace(request.Specialization))
        {
            craftsman = craftsman.Where(c =>
                EF.Functions.Like(c.Specialization.Name, 
                    $"%{request.Specialization}%"));
        }

        if (request.Availability.HasValue)
        {
            craftsman = craftsman.Where(c => c.IsAvialable == request.Availability.Value);
        }

        if (request.ProfileVerified.HasValue)
        {
            craftsman = craftsman.Where(c => c.ProfileVerified == request.ProfileVerified.Value);
        }

        if (request.MinExperience.HasValue)
        {
            craftsman = craftsman.Where(c => c.Experience >= request.MinExperience.Value);
        }

        if (request.MinRating.HasValue)
        {
            craftsman = craftsman.Where(c => c.Rating >= request.MinRating.Value);
        }
        
        var craftsmen = await craftsman.ToListAsync(cancellationToken);
        
        return craftsmen.ToCraftsmanDtos();
    }
}