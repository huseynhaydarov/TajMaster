using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Services.Commands.Update;

namespace TajMaster.WebApi.Endpoints.Services;

public class UpdateServiceEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/api/services/{id}", async (Guid id, [FromBody] UpdateServiceCommand command, 
                ISender mediator) =>
            {
                if (id != command.ServiceId)
                {
                    return Results.BadRequest();
                }
                
                await mediator.Send(command);

                return Results.NoContent();
            })
            .RequireAuthorization("AdminPolicy")
            .WithName("UpdateServiceEndpoint")
            .WithTags("Services");
    }
}