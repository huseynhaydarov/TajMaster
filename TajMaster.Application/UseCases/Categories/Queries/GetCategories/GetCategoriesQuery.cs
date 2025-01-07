using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Pagination;

namespace TajMaster.Application.UseCases.Categories.Queries.GetCategories;

public record GetCategoriesQuery(PagingParameters PagingParameters) : IQuery<PaginatedResult<CategoryDto.CategoryDto>>;