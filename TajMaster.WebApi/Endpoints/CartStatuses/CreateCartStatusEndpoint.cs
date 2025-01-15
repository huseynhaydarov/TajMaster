using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.CartStatuses.Command.Create;

namespace TajMaster.WebApi.Endpoints.CartStatuses;

public class CreateCartStatusEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/cart-statuses", async (ISender mediator, [FromBody] CreateCartStatusCommand command) =>
            {
                var cartStatusId = await mediator.Send(command);
                
                return Results.Created($"/cart-statuses/{cartStatusId}", new { Id = cartStatusId });
            })
            .WithName("CreateCartStatusEndpoint")
            .WithTags("CartStatuses");
    }
}