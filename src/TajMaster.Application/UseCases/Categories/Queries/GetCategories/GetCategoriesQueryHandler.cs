using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TajMaster.Application.Common.Interfaces.CacheService;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.Categories.CategoryDtos;
using TajMaster.Application.UseCases.Services.ServiceDtos;

namespace TajMaster.Application.UseCases.Categories.Queries.GetCategories;

public class GetCategoriesQueryHandler(
    IApplicationDbContext context,
    ICacheService cacheService,
    ILogger<GetCategoriesQueryHandler> logger)
    : IQueryHandler<GetCategoriesQuery, PaginatedResult<CategorySummaryDto>>
{
    public async Task<PaginatedResult<CategorySummaryDto>> Handle(GetCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var pagingParams = request.PagingParameters;

        var cacheKey = "Categories";
        
        var categoriesCache = await cacheService.GetOrSetAsync(cacheKey, async () =>
        {
            logger.LogInformation("Cache miss. Fetching categories from database.");
            var query = context.Categories
                .AsNoTracking()
                .Include(c => c.CategoryServices)
                    .ThenInclude(cs => cs.Service)
                .AsQueryable();

            var totalCount = await query.CountAsync(cancellationToken);
            var paginatedCategories = await query
                .Skip(pagingParams.Skip)
                .Take(pagingParams.Take)
                .ToListAsync(cancellationToken);

            var categoriesDto = paginatedCategories.Select(category 
                => new CategorySummaryDto(
                    category.Id,
                    category.Name,
                    category.Description,
                    category.CategoryServices
                        .Select(cs => new ServiceDetailDto(
                            cs.Service.Id,
                            cs.Service.Title,
                            cs.Service.Description,
                            cs.Service.BasePrice,
                            cs.Service.CategoryServices
                                .Select(serviceCategory => new CategoryDto(
                                    serviceCategory.Category.Id,
                                    serviceCategory.Category.Name,
                                    serviceCategory.Category.Description))
                                .ToList()))
                        .ToList()))
                .ToList();

            return new PaginatedResult<CategorySummaryDto>(
                pagingParams.PageNumber!.Value,
                pagingParams.PageSize!.Value,
                totalCount,
                categoriesDto
            );
        });

        return categoriesCache!;
     }
}
