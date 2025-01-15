using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Specializations.Command.Create;

namespace TajMaster.WebApi.Endpoints.Specializations;

public class CreateSpecializationEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        // Create Specialization
        app.MapPost("/api/specializations", async (ISender mediator, [FromBody] CreateSpecializationCommand command) =>
        {
            var specializationId = await mediator.Send(command);
            return Results.Created($"/api/specializations/{specializationId}", new { Id = specializationId });
        }).WithName("CreateSpecialization");
    }
}