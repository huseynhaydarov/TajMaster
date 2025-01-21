using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.Services.ServiceDtos;
using TajMaster.Application.UseCases.Services.ServiceExtensions;

namespace TajMaster.Application.UseCases.Services.Queries.GetServices;

public class GetServicesQueryHandler(
    IApplicationDbContext context)
    : IQueryHandler<GetServicesQuery, PaginatedResult<ServiceSummaryDto>>
{
    public async Task<PaginatedResult<ServiceSummaryDto>> Handle(GetServicesQuery query,
        CancellationToken cancellationToken)
    {
        var pagingParams = query.PagingParameters;

        var request = context.Services
            .AsNoTracking()
            .Include(u => u.CategoryServices)
            .AsQueryable();


        request = pagingParams.OrderByDescending == true
            ? request.OrderByDescending(s => s.Id)
            : request.OrderBy(u => u.Id);

        var totalCount = await request.CountAsync(cancellationToken);

        var serviceDtos = request.ToServiceDtoList();

        var paginatedResult = new PaginatedResult<ServiceSummaryDto>(
            (int)pagingParams.PageNumber!,
            (int)pagingParams.PageSize!,
            totalCount,
            serviceDtos
        );

        return paginatedResult;
    }
}