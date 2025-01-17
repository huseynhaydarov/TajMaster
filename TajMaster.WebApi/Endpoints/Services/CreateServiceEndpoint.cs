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
                var newService = await mediator.Send(command);
                
                return Results.Created($"api/services/{newService}", new { Id = newService });
            })
            .WithName("CreateServiceEndpoint")
            .WithTags("Services");
    }
}