using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Orders.Commands.Update;

namespace TajMaster.WebApi.Endpoints.Orders;

public class UpdateOrderStatusEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
            app.MapPatch("/api/orders/{orderId:guid}/status", async (
                [FromRoute] Guid orderId,
                [FromBody] UpdateOrderStatusCommand command,
                ISender mediator,
                CancellationToken cancellationToken) =>
            { 
                command = command with { OrderId = orderId };

                await mediator.Send(command, cancellationToken);

                return Results.NoContent(); 
            })
            .RequireAuthorization("AdminOrCraftsmanPolicy")
            .WithName("UpdateOrderStatusEndpoint")
            .WithTags("Orders");
    }
}
