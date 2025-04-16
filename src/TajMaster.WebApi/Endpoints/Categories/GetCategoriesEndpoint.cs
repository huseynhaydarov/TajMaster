using Carter;
using MediatR;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.Categories.CategoryDtos;
using TajMaster.Application.UseCases.Categories.Queries.GetCategories;

namespace TajMaster.WebApi.Endpoints.Categories;

public class GetCategoriesEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/categories", async ([AsParameters] PagingParameters pagingParameters, 
                ISender mediator, CancellationToken cancellationToken) =>
            {
                var results = await mediator
                    .Send(new GetCategoriesQuery(pagingParameters), cancellationToken);

                return Results.Ok(results);
            })
            .AllowAnonymous()
            .WithName("GetCategoriesEndpoint")
            .WithTags("Categories")
            .Produces<PaginatedResult<CategoryDto>>();
    }
}