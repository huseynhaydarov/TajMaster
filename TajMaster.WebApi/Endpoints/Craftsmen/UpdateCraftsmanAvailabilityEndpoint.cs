using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Craftsmen.Commands.Update.UpdateAvailability;

namespace TajMaster.WebApi.Endpoints.Craftsmen;

public class UpdateCraftsmanAvailabilityEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPatch("/api/craftsmen/{id:guid}/availability", async (
                [FromRoute] Guid id,
                [FromBody] bool isAvailable,
                ISender mediator,
                CancellationToken cancellationToken
            ) =>
            {
                await mediator.Send(new UpdateCraftsmanAvailabilityCommand(id, isAvailable), cancellationToken);

                return Results.NoContent();
            })
            .WithName("UpdateCraftsmanAvailabilityEndpoint")
            .WithTags("Craftsmen");
    }
}