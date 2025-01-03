using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Services.Commands.Update;

namespace TajMaster.WebApi.Endpoints.Services;

public class UpdateServiceEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/api/services/{id}", async (ISender mediator, int id, [FromBody] UpdateServiceCommand command) =>
            {
                if (id != command.ServiceId) return Results.BadRequest();
                var result = await mediator.Send(command);
                return result ? Results.NoContent() : Results.NotFound();
            })
            .WithName("UpdateServiceEndpoint")
            .WithTags("Services");
    }
}