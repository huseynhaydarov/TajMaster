using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Services.Commands.Create;

namespace TajMaster.WebApi.Endpoints.Services;

public class CreateServiceEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/services", async (ISender mediator, [FromBody] CreateServiceCommand command) =>
            {
                var serviceId = await mediator.Send(command);
                return Results.Created($"/services/{serviceId}", new { Id = serviceId });
            })
            .WithName("CreateServiceEndpoint")
            .WithTags("Services");
    }
}