using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Craftsmen.Commands.Delete;

namespace TajMaster.WebApi.Endpoints.Craftsmen;

public class DeleteCraftsmanEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/craftsman/{id}", async (ISender mediator, [FromRoute] int id) =>
            {
                var result = await mediator.Send(new DeleteCraftsmanCommand(id));
                return result ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteCraftsmanEndpoint")
            .WithTags("Craftsmen");
    }
}