using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Craftsmen.Commands.Update.UpdateCraftsman;

namespace TajMaster.WebApi.Endpoints.Craftsmen;

public class UpdateCraftsmanEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/api/craftsman/{id}", async (ISender mediator, int id, [FromBody] UpdateCraftsmanCommand command) =>
            {
                if (id != command.CraftsmanId) return Results.BadRequest();
                var result = await mediator.Send(command);
                return result ? Results.NoContent() : Results.NotFound();
            })
            .WithName("UpdateCraftsmanEndpoint")
            .WithTags("Craftsmen");
    }
}