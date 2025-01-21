using Carter;
using MediatR;
using TajMaster.Application.UseCases.Craftsmen.Commands.Create.CreateCraftsman;

namespace TajMaster.WebApi.Endpoints.Craftsmen;

public class CreateCraftsmenEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/users/craftsmen", async (CreateCraftsmanCommand command, ISender mediator) =>
            {
                var result = await mediator.Send(command);

                return Results.Created($"api/users/craftsmen/{result}", new { Id = result });
            })
            .WithName("CreateCraftsmanEndpoint")
            .WithTags("Craftsmen");
    }
}