using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Services.Commands.Create;

namespace TajMaster.WebApi.Endpoints.Services;

public class CreateServiceEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/services", async ([FromBody] CreateServiceCommand command, ISender mediator, 
                CancellationToken cancellationToken) =>
            {
                var newService = await mediator.Send(command, cancellationToken);

                return Results.Created($"api/services/{newService}", new { Id = newService });
            })
            .RequireAuthorization("AdminPolicy")
            .WithName("CreateServiceEndpoint")
            .WithTags("Services");
    }
}