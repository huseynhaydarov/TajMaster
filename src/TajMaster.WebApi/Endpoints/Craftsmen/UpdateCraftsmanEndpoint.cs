using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Craftsmen.Commands.Update.UpdateCraftsman;

namespace TajMaster.WebApi.Endpoints.Craftsmen;

public class UpdateCraftsmanEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/api/craftsman/{id:guid}", async (Guid id,
                ISender mediator,
                [FromBody] UpdateCraftsmanCommand command) =>
            {
                if (id != command.CraftsmanId)
                {
                    return Results.BadRequest();
                } 
                
                await mediator.Send(command);

                return Results.NoContent();
            })
            .RequireAuthorization("AdminOrCraftsmanPolicy")
            .WithName("UpdateCraftsmanEndpoint")
            .WithTags("Craftsmen");
    }
}