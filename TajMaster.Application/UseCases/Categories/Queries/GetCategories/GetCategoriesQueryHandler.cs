using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Pagination;

namespace TajMaster.Application.UseCases.Categories.Queries.GetCategories;

public class GetCategoriesQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetCategoriesQuery, PaginatedResult<CategoryDto.CategoryDto>>
{
    public async Task<PaginatedResult<CategoryDto.CategoryDto>> Handle(GetCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var pagingParams = request.PagingParameters;

        var paginatedCategories = await unitOfWork.CategoryRepository.GetAllAsync(pagingParams, cancellationToken);

        var totalCount = paginatedCategories.Count();

        var categoriesDto = paginatedCategories
            .Select(category => new CategoryDto.CategoryDto(
                category.Id,
                category.Name,
                category.Description))
            .ToList();

        var paginatedResult = new PaginatedResult<CategoryDto.CategoryDto>(
            (int)pagingParams.PageNumber!,
            (int)pagingParams.PageSize!,
            totalCount,
            categoriesDto
        );

        return paginatedResult;
    }
}