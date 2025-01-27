using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Specializations.SpecializationDtos;
using TajMaster.Application.Common.Interfaces.CacheService;
using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.Specializations.Queries.GetById;

public class GetSpecializationByIdQueryHandler(
    IApplicationDbContext context,
    ICacheService cacheService,
    ILogger<GetSpecializationByIdQueryHandler> logger)
    : IQueryHandler<GetSpecializationByIdQuery, SpecializationDto>
{
    public async Task<SpecializationDto> Handle(GetSpecializationByIdQuery query, CancellationToken cancellationToken)
    {
        var cacheKey = $"Specialization_{query.SpecializationId}";
        
        var specialization = await cacheService.GetOrSetAsync(cacheKey,
            async () =>
            {
                logger.LogInformation("Cache miss. Fetching data for key: {CacheKey} from database.", cacheKey);
                var specializationEntity = await context.Specializations
                    .FirstOrDefaultAsync(s => s.Id == query.SpecializationId, cancellationToken);

                if (specializationEntity == null)
                {
                    logger.LogWarning("Specialization with ID {SpecializationId} not found.", query.SpecializationId);
                    throw new NotFoundException($"Specialization with ID {query.SpecializationId} not found.");
                }
                
                return new SpecializationDto(
                    specializationEntity.Id,
                    specializationEntity.Name,
                    specializationEntity.Description);
            });

        return specialization ?? throw new NullReferenceException("Specialization data is null.");
    }
}