using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Craftsmen.Commands.Delete;

namespace TajMaster.WebApi.Endpoints.Craftsmen;

public class DeleteCraftsmanEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/craftsman/{id:guid}", async ([FromRoute] Guid id, ISender mediator) =>
            {
               await mediator.Send(new DeleteCraftsmanCommand(id));

                return Results.NoContent();
            })
            .RequireAuthorization("AdminOrCraftsmanPolicy")
            .WithName("DeleteCraftsmanEndpoint")
            .WithTags("Craftsmen");
    }
}