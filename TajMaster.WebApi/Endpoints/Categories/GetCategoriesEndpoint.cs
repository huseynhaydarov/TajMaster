using Carter;
using MediatR;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.Categories.Queries.GetCategories;
using TajMaster.Application.UseCases.DTO;
using TajMaster.Application.UseCases.Users.Queries.GetUsers;

namespace TajMaster.WebApi.Endpoints.Categories;

public class GetCategoriesEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/categories", async ([AsParameters] PagingParameters pagingParameters, ISender mediator) =>
            {
                var results = await mediator.Send(new GetCategoriesQuery(pagingParameters));

                return Results.Ok(results);
            })
            .WithName("GetCategoriesEndpoint")
            .Produces<PaginatedResult<CategoryDto>>();
    }
}