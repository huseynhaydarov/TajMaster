using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TajMaster.Application.Common.Interfaces.CacheService;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.Services.ServiceDtos;
using TajMaster.Application.UseCases.Services.ServiceExtensions;

namespace TajMaster.Application.UseCases.Services.Queries.GetServices;

public class GetServicesQueryHandler(
    IApplicationDbContext context,
    ICacheService cacheService,
    ILogger<GetServicesQueryHandler> logger)
    : IQueryHandler<GetServicesQuery, PaginatedResult<ServiceSummaryDto>>
{
    public async Task<PaginatedResult<ServiceSummaryDto>> Handle(
        GetServicesQuery request, CancellationToken cancellationToken)
    {
        var pagingParams = request.PagingParameters;

        const string cacheKey = "Services";

        var servicesCache = await cacheService.GetOrSetAsync(cacheKey, async () =>
        {
            logger.LogInformation("Cache miss. Fetching services from database.");

            var query = context.Services
                .AsNoTracking()
                .Include(s => s.CategoryServices)
                    .ThenInclude(cs => cs.Category)
                .AsSplitQuery()
                .AsQueryable();
            
            query = pagingParams.OrderByDescending == true
                ? query.OrderByDescending(s => s.Id)
                : query.OrderBy(s => s.Id);
            
            var totalCount = await query.CountAsync(cancellationToken);
            
            var paginatedServices = await query
                .Skip(pagingParams.Skip)
                .Take(pagingParams.Take)
                .ToListAsync(cancellationToken);

            var serviceDtos = paginatedServices.ToServiceDtoList();

            return new PaginatedResult<ServiceSummaryDto>(
                pagingParams.PageNumber!.Value,
                pagingParams.PageSize!.Value,
                totalCount,
                serviceDtos
            );
        });

        return servicesCache!;
    }
}
