using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Categories.CategoryDtos;
using TajMaster.Application.Common.Interfaces.CacheService;
using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.Categories.Queries.GetCategory;

public class GetCategoryByIdQueryHandler(
    IApplicationDbContext context,
    ICacheService cacheService,
    ILogger<GetCategoryByIdQueryHandler> logger)
    : IQueryHandler<GetCategoryByIdQuery, CategoryDto>
{
    public async Task<CategoryDto> Handle(GetCategoryByIdQuery command, CancellationToken cancellationToken)
    {
        var cacheKey = $"Category_{command.CategoryId}";
        
        var category = await cacheService.GetOrSetAsync(cacheKey,
            async () =>
            {
                logger.LogInformation("Cache miss. Fetching data for key: {CacheKey} from database.", cacheKey);
                var categoryEntity = await context.Categories
                    .FirstOrDefaultAsync(c => c.Id == command.CategoryId, cancellationToken);

                if (categoryEntity == null)
                {
                    logger.LogWarning("Category with ID {CategoryId} not found.", command.CategoryId);
                    throw new NotFoundException($"Category with ID {command.CategoryId} not found.");
                }

                return new CategoryDto(
                    categoryEntity.Id,
                    categoryEntity.Name,
                    categoryEntity.Description
                );
            });

        if (category == null)
        {
            throw new NotFoundException($"Category with ID {command.CategoryId} not found.");
        }
        return category;
    }
}
