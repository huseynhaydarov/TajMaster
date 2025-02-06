using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Services.Commands.Delete;

namespace TajMaster.WebApi.Endpoints.Services;

public class DeleteServiceEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/services/{id:guid}", async ([FromRoute] Guid id, ISender mediator, 
                CancellationToken cancellationToken) =>
            {
              await mediator.Send(new DeleteServiceCommand(id), cancellationToken);

              return Results.NoContent();
            })
            .RequireAuthorization("AdminPolicy")
            .WithName("DeleteServiceEndpoint")
            .WithTags("Services");
    }
}