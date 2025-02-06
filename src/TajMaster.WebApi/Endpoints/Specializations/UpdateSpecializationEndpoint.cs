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
                async (Guid id, [FromBody] UpdateSpecializationCommand command, ISender mediator, 
                    CancellationToken cancellationToken) =>
                {
                    if (id != command.SpecializationId)
                    {
                        return Results.BadRequest();
                    }
                    
                    await mediator.Send(command, cancellationToken);

                   return Results.NoContent();
                })
            .RequireAuthorization("AdminPolicy")
            .WithName("UpdateSpecializationEndpoint")
            .WithTags("Specializations");
    }
}