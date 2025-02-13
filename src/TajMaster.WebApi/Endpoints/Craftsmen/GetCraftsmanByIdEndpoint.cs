using Carter;
using MediatR;
using TajMaster.Application.UseCases.Craftsmen.Queries.GetCraftsman;

namespace TajMaster.WebApi.Endpoints.Craftsmen;

public class GetCraftsmanByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/craftsman/{id:guid}", async (Guid id, ISender mediator, 
                CancellationToken cancellationToken) =>
            {
                var craftsman = await mediator.Send(new GetCraftsmanByIdQuery(id), cancellationToken);

                return Results.Ok(craftsman);
            })
            .RequireAuthorization("AdminOrCraftsmanPolicy")
            .WithName("GetCraftsmanByIdEndpoint")
            .WithTags("Craftsmen");
    }
}