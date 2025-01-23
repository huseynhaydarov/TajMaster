using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Specializations.Commands.Update;

namespace TajMaster.WebApi.Endpoints.Specializations;

public class UpdateSpecializationEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/api/specializations/{id:guid}",
                async (ISender mediator, Guid id, [FromBody] UpdateSpecializationCommand command) =>
                {
                    if (id != command.SpecializationId)
                        return Results.BadRequest(new { Error = "Specialization ID mismatch." });

                    var result = await mediator.Send(command);

                    return result ? Results.Ok() : Results.BadRequest();
                })
            .RequireAuthorization("AdminPolicy")
            .WithName("UpdateSpecializationEndpoint")
            .WithTags("Specializations");
    }
}