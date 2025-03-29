using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Specializations.Commands.Create;

public class CreateSpecializationCommandHandler(
    IApplicationDbContext context,
    IDistributedCache cache,
    ILogger<CreateSpecializationCommandHandler> logger,
    IMapper mapper)
    : ICommandHandler<CreateSpecializationCommand, Guid>
{
    public async Task<Guid> Handle(CreateSpecializationCommand command, CancellationToken cancellationToken)
    {
        const string cacheKey = "Specializations";
        
        var specialization = mapper.Map<Specialization>(command);
        
        context.Specializations.Add(specialization);
        
        await context.SaveChangesAsync(cancellationToken);
        
        logger.LogInformation("Invalidating cache for key: {CacheKey} from cache.", cacheKey);
        
        await cache.RemoveAsync(cacheKey, cancellationToken);

        return specialization.Id;
    }
}