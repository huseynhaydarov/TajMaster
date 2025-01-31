using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Categories.Commands.Create;

public class CreateCategoryCommandHandler(
    IApplicationDbContext context,
    IDistributedCache cache,
    ILogger<CreateCategoryCommandHandler> logger,
    IMapper mapper)
    : IRequestHandler<CreateCategoryCommand, Guid>
{
    public async Task<Guid> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = mapper.Map<Category>(command);

        context.Categories.Add(category);

        await context.SaveChangesAsync(cancellationToken);
        
        const string cacheKey = "Categories";
        logger.LogInformation("invalidating cache for key: {CacheKey} from cache.", cacheKey);
        await cache.RemoveAsync(cacheKey, cancellationToken);

        return category.Id;
    }
}