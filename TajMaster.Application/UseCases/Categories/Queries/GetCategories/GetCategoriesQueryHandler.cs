using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.DTO;

namespace TajMaster.Application.UseCases.Categories.Queries.GetCategories;

public class GetCategoriesQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetCategoriesQuery, PaginatedResult<CategoryDto>>
{
    public async Task<PaginatedResult<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var pagingParams = request.PagingParameters;

        var paginatedCategories = await unitOfWork.CategoryRepository.GetAllAsync(pagingParams, cancellationToken);

        var totalCount = paginatedCategories.Count();

        var categoriesDto = paginatedCategories
            .Select(category => new CategoryDto(
                category.Id,
                category.Name,
                category.Description,
                category.Services.Select(service => new ServiceDto(
                    service.Id,
                    service.Title,
                    service.Description,
                    service.BasePrice,
                    null 
                )).ToList()))
            .ToList();
        
        var paginatedResult = new PaginatedResult<CategoryDto>(
            (int)pagingParams.PageNumber!,
            (int)pagingParams.PageSize!,
            totalCount,
            categoriesDto
        );

        return paginatedResult;
    }
}

