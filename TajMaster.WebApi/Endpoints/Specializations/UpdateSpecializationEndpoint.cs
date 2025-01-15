using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Specializations.Commands.Update;

namespace TajMaster.WebApi.Endpoints.Specializations;

public class UpdateSpecializationEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        // Update Specialization
        app.MapPut("/api/specializations/{id}", async (ISender mediator, Guid id, [FromBody] UpdateSpecializationCommand command) =>
        {
            if (id != command.SpecializationId) return Results.BadRequest();
            var result = await mediator.Send(command);
            return result ? Results.Ok() : Results.BadRequest("Failed to update specialization.");
        }).WithName("UpdateSpecialization");
    }
}