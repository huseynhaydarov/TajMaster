using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Craftsmen.Commands.Create;
using TajMaster.Application.UseCases.Users.Commands.Create;

namespace TajMaster.WebApi.Endpoints.Craftsmen;

public class CreateCraftsmanEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/craftsmen", async (ISender mediator, [FromBody] CreateCraftsmanCommand command) =>
            {
                var craftsmanId = await mediator.Send(command);
                return Results.Created($"/craftsmen/{craftsmanId}", new { Id = craftsmanId });
            })
            .WithName("CreateCraftsmanEndpoint")
            .WithTags("Craftsmen");
    }
}