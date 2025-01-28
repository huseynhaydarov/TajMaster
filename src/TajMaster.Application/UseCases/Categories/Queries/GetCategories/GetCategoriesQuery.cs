using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.Categories.CategoryDtos;

namespace TajMaster.Application.UseCases.Categories.Queries.GetCategories;

public record GetCategoriesQuery(PagingParameters PagingParameters) 
    : IQuery<PaginatedResult<CategorySummaryDto>>;