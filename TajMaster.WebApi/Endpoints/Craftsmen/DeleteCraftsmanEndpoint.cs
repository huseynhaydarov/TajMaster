using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Craftsmen.Commands.Delete;

namespace TajMaster.WebApi.Endpoints.Craftsmen;

public class DeleteCraftsmanEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/craftsman/{id}", async (ISender mediator, [FromRoute] Guid id) =>
            {
                var result = await mediator.Send(new DeleteCraftsmanCommand(id));
                return result ? Results.NoContent() : Results.NotFound(new { message = "Craftsmen not found." });
            })
            .WithName("DeleteCraftsmanEndpoint")
            .WithTags("Craftsmen");
    }
}