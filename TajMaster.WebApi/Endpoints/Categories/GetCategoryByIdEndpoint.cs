using Carter;
using MediatR;
using TajMaster.Application.UseCases.Categories.Queries.GetCategory;

namespace TajMaster.WebApi.Endpoints.Categories;

public class GetCategoryByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/categories/{id}", async (ISender mediator, int id) =>
            {
                var category = await mediator.Send(new GetCategoryByIdQuery(id));
                return Results.Ok(category);
            })
            .WithName("GetCategoryByIdEndpoint")
            .WithTags("Categories");
    }
}