using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Pagination;

namespace TajMaster.Application.UseCases.Categories.Queries.GetCategories;

public class GetCategoriesQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetCategoriesQuery, PaginatedResult<CategoryDtos.CategoryDto>>
{
    public async Task<PaginatedResult<CategoryDtos.CategoryDto>> Handle(GetCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var pagingParams = request.PagingParameters;
        
        var query = context.Categories.AsQueryable();

        var totalCount = await query.CountAsync(cancellationToken);  // Get the total count for pagination
        
        var paginatedCategories = await query
            .Skip(pagingParams.Skip)
            .Take(pagingParams.Take)
            .ToListAsync(cancellationToken);
        
        var categoriesDto = paginatedCategories.Select(category => new CategoryDtos.CategoryDto(
                category.Id,
                category.Name,
                category.Description))
            .ToList();
        
        return new PaginatedResult<CategoryDtos.CategoryDto>(
            pagingParams.PageNumber!.Value,
            pagingParams.PageSize!.Value,
            totalCount,
            categoriesDto
        );
    }
}