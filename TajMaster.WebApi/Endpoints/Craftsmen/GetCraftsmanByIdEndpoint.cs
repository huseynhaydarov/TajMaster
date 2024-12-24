using Carter;
using MediatR;
using TajMaster.Application.UseCases.Craftsmen.Queries.GetCraftsman;


namespace TajMaster.WebApi.Endpoints.Craftsmen;

public class GetCraftsmanByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/craftsman/{id}", async (ISender mediator, int id) =>
            {
                var craftsman = await mediator.Send(new GetCraftsmanByIdQuery(id));
                return Results.Ok(craftsman);
            })
            .WithName("GetCraftsmanByIdEndpoint")
            .WithTags("Craftsmen");
    }
}