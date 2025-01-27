using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Interfaces.CacheService;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Services.ServiceDtos;
using TajMaster.Application.UseCases.Services.ServiceExtensions;

namespace TajMaster.Application.UseCases.Services.Queries.GetServiceByCategory;

public class GetServicesByCategoryQueryHandler(
    IApplicationDbContext context,
    ICacheService cacheService,
    ILogger<GetServicesByCategoryQueryHandler> logger)
    : IQueryHandler<GetServicesByCategoryQuery, IEnumerable<ServiceSummaryDto>>
{
    public async Task<IEnumerable<ServiceSummaryDto>> Handle(GetServicesByCategoryQuery query, CancellationToken cancellationToken)
    {
        var cacheKey = $"Services_ByCategory_{query.CategoryId}";
        
        var servicesDtoList = await cacheService.GetOrSetAsync(cacheKey,
            async () =>
            {
                logger.LogInformation("Cache miss. Fetching services for Category ID {CategoryId} from the database.", query.CategoryId);
                
                var services = await context.Services
                    .AsNoTracking()
                    .Include(service => service.CategoryServices)
                        .ThenInclude(cs => cs.Category)
                    .Where(service => service.CategoryServices.Any(cs => cs.CategoryId == query.CategoryId))
                    .ToListAsync(cancellationToken);

                if (services == null || !services.Any())
                {
                    logger.LogWarning("No services found for Category ID {CategoryId}.", query.CategoryId);
                    throw new NotFoundException($"No services found for category with ID {query.CategoryId}");
                }
                
                return services.ToServiceDtoList();
            },
            new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
            });

        if (servicesDtoList == null || !servicesDtoList.Any())
        {
            throw new NullReferenceException("Retrieved services DTO list is null or empty.");
        }

        logger.LogInformation("Successfully retrieved {ServiceCount} services for Category ID {CategoryId}.", servicesDtoList.Count(), query.CategoryId);

        return servicesDtoList;
    }
}
