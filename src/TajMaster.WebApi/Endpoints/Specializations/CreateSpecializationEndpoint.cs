using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Specializations.Commands.Create;

namespace TajMaster.WebApi.Endpoints.Specializations;

public class CreateSpecializationEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/specializations", async ([FromBody] CreateSpecializationCommand command, 
                ISender mediator, CancellationToken cancellationToken) =>
            {
                var newSpecialization = await mediator.Send(command, cancellationToken);

                return Results.Created($"/api/specializations/{newSpecialization}", new { Id = newSpecialization });
            })
            .RequireAuthorization("AdminPolicy")
            .WithName("CreateSpecializationEndpoint")
            .WithTags("Specializations");
        ;
    }
}