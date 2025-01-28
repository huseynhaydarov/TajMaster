using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Interfaces.CacheService;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Services.ServiceDtos;
using TajMaster.Application.UseCases.Services.ServiceExtensions;

namespace TajMaster.Application.UseCases.Services.Queries.GetService;

public class GetServiceByIdQueryHandler(
    IApplicationDbContext context,
    ICacheService cacheService,
    ILogger<GetServiceByIdQueryHandler> logger)
    : IQueryHandler<GetServiceByIdQuery, ServiceDetailDto>
{
    public async Task<ServiceDetailDto> Handle(GetServiceByIdQuery query, CancellationToken cancellationToken)
    {
        var cacheKey = $"Service_{query.ServiceId}";
        
        var serviceDto = await cacheService.GetOrSetAsync(cacheKey,
            async () =>
            {
                logger.LogInformation("Cache miss. Fetching Service ID {ServiceId} from the database.", query.ServiceId);
                
                var service = await context.Services
                    .AsNoTracking() 
                    .Include(s => s.CategoryServices)
                        .ThenInclude(cs => cs.Category)
                    .FirstOrDefaultAsync(s => s.Id == query.ServiceId, cancellationToken);

                if (service == null)
                {
                    logger.LogWarning("Service with ID {ServiceId} not found.", query.ServiceId);
                    throw new NotFoundException($"Service with ID {query.ServiceId} not found.");
                }

                return service.ToServiceDto();
            },
            new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
            });

        if (serviceDto == null)
        {
            throw new NullReferenceException("Retrieved service DTO is null.");
        }

        logger.LogInformation("Successfully retrieved Service ID {ServiceId}.", query.ServiceId);

        return serviceDto;
    }
}
