using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.Craftsmen.CraftsmanDTos;
using TajMaster.Application.UseCases.Craftsmen.CraftsmenExtension;

namespace TajMaster.Application.UseCases.Craftsmen.Queries.GetCraftsmen;

public class GetCraftsmenQueryHandler(IApplicationDbContext context)
    : IQueryHandler<GetCraftsmenQuery, PaginatedResult<CraftsmanDto>>
{
    public async Task<PaginatedResult<CraftsmanDto>> Handle(GetCraftsmenQuery request,
        CancellationToken cancellationToken)
    {
        var pagingParams = request.PagingParameters;

        var query = context.Craftsmen.AsNoTracking();

        if (pagingParams.OrderByDescending == true)
        {
            query = query.OrderByDescending(c => c.Id);
        }
        else
        {
            query = query.OrderBy(c => c.Id);
        }

        var totalCount = await query.CountAsync(cancellationToken);

        var paginatedCraftsmen = await query
            .Skip(pagingParams.Skip)
            .Take(pagingParams.Take)
            .ToListAsync(cancellationToken);

        var craftsmanDtos = paginatedCraftsmen.ToCraftsmanDtos();

        return new PaginatedResult<CraftsmanDto>(
            pagingParams.PageNumber!.Value,
            pagingParams.PageSize!.Value,
            totalCount,
            craftsmanDtos.ToList()
        );
    }
}