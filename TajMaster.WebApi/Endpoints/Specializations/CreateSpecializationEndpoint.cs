using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Specializations.Commands.Create;

namespace TajMaster.WebApi.Endpoints.Specializations;

public class CreateSpecializationEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/specializations", async (ISender mediator, [FromBody] CreateSpecializationCommand command) =>
            {
                var newSpecialization = await mediator.Send(command);

                return Results.Created($"/api/specializations/{newSpecialization}", new { Id = newSpecialization });
            })
            .WithName("CreateSpecializationEndpoint")
            .WithTags("Specializations");
        ;
    }
}