using Carter;
using MediatR;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.Categories.CategoryDto;
using TajMaster.Application.UseCases.Categories.CategoryDtos;
using TajMaster.Application.UseCases.Categories.Queries.GetCategories;

namespace TajMaster.WebApi.Endpoints.Categories;

public class GetCategoriesEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/categories", async ([AsParameters] 
                PagingParameters pagingParameters, ISender mediator) =>
            {
                var results = await mediator.Send(new GetCategoriesQuery(pagingParameters));
                
                return Results.Ok(results);
            })
            .WithName("GetCategoriesEndpoint")
            .WithTags("Categories")
            .Produces<PaginatedResult<CategoryDto>>();
    }
}