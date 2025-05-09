using Carter;
using MediatR;
using TajMaster.Application.UseCases.Craftsmen.Commands.Create.CreateCraftsman;

namespace TajMaster.WebApi.Endpoints.Craftsmen;

public class CreateCraftsmenEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/users/craftsmen", async (CreateCraftsmanCommand command, ISender mediator,
            CancellationToken cancellationToken) =>
            {
                var result = await mediator.Send(command, cancellationToken);

                return Results.Created($"api/users/craftsmen/{result}", new { Id = result });
            })
            .RequireAuthorization()
            .AllowAnonymous()
            .WithName("CreateCraftsmanEndpoint")
            .WithTags("Craftsmen");
    }
}