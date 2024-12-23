using Carter;
using MediatR;
using TajMaster.Application.UseCases.Categories.Queries;
using TajMaster.Application.UseCases.Categories.Queries.GetCategory;
using TajMaster.Application.UseCases.Users.Queries.GetUser;

namespace TajMaster.WebApi.Endpoints.Categories;

public class GetCategoryByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/categories/{id}", async (ISender mediator, int id) =>
            {
                var category = await mediator.Send(new GetCategoryByIdQuery(id));
                return Results.Ok(category);
            })
            .WithName("GetCategoryByIdEndpoint");
    }
}