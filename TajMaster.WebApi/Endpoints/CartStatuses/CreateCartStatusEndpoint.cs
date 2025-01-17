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
                var newCartStatus = await mediator.Send(command);
                
                return Results.Created($"/api/cart-statuses/{newCartStatus}", new { Id = newCartStatus });
            })
            .WithName("CreateCartStatusEndpoint")
            .WithTags("CartStatuses");
    }
}