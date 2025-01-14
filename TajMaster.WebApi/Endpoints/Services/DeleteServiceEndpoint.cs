using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Services.Commands.Delete;

namespace TajMaster.WebApi.Endpoints.Services;

public class DeleteServiceEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/services/{id}", async (ISender mediator, [FromRoute] Guid id) =>
            {
                var result = await mediator.Send(new DeleteServiceCommand(id));
                return result ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteServiceEndpoint")
            .WithTags("Services");
    }
}