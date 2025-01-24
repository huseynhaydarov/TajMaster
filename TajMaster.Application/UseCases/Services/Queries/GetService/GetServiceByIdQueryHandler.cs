using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Services.ServiceDtos;
using TajMaster.Application.UseCases.Services.ServiceExtensions;
using TajMaster.Application.Common.Interfaces;
using TajMaster.Application.Common.Interfaces.CacheService;

namespace TajMaster.Application.UseCases.Services.Queries.GetService
{
    public class GetServiceByIdQueryHandler(
        IApplicationDbContext context, 
        ICacheService cacheService)
        : IRequestHandler<GetServiceByIdQuery, ServiceDetailDto>
    {
        public async Task<ServiceDetailDto> Handle(GetServiceByIdQuery query, CancellationToken cancellationToken)
        {
            var cacheKey = $"Service_{query.ServiceId}"; 
            
            if (cacheService.TryGetValue(cacheKey, out ServiceDetailDto? cachedService))
            {
                return cachedService ?? throw new InvalidOperationException("Cached service was null.");
            }
            
            var service = await context.Services
                .Include(s => s.CategoryServices)
                    .ThenInclude(cs => cs.Category)
                .FirstOrDefaultAsync(s => s.Id == query.ServiceId, cancellationToken);

            if (service == null)
            {
                throw new NotFoundException($"Service with ID {query.ServiceId} not found.");
            }
            
            var serviceDto = service.ToServiceDto();
            
            await cacheService.SetAsync(cacheKey, serviceDto, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30) // Set cache expiration
            });

            return serviceDto;
        }
    }
}
