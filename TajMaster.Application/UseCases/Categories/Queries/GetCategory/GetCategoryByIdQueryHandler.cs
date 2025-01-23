using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Categories.CategoryDtos;
using TajMaster.Application.Common.Interfaces;

namespace TajMaster.Application.UseCases.Categories.Queries.GetCategory
{
    public class GetCategoryByIdQueryHandler(
        IApplicationDbContext context,
        ICacheService cacheService,
        ILogger<GetCategoryByIdQueryHandler> logger)
        : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
    {
        public async Task<CategoryDto> Handle(GetCategoryByIdQuery command, CancellationToken cancellationToken)
        {
            var cacheKey = $"Category_{command.CategoryId}";
             
            if (cacheService.TryGetValue(cacheKey, out CategoryDto? cachedCategory))
            {
                return cachedCategory ?? throw new InvalidOperationException("Cached category data is invalid.");
            }

            try
            {
                var category = await context.Categories
                    .FirstOrDefaultAsync(c => c.Id == command.CategoryId, cancellationToken);

                if (category == null)
                {
                    logger.LogWarning("Category with ID {CategoryId} not found.", command.CategoryId);
                    throw new NotFoundException($"Category with ID {command.CategoryId} not found.");
                }

                var categoryDto = new CategoryDto(
                    category.Id,
                    category.Name,
                    category.Description
                );
                
                await cacheService.SetAsync(cacheKey, categoryDto, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30) 
                });

                return categoryDto;
            }
            catch (NotFoundException ex)
            {
                logger.LogError(ex, "Error occurred while fetching category with ID {CategoryId}", command.CategoryId);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An unexpected error occurred while fetching category with ID {CategoryId}", command.CategoryId);
                throw;
            }
        }
    }
}
