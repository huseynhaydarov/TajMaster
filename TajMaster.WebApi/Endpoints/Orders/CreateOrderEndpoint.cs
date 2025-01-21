using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Orders.Create;

namespace TajMaster.WebApi.Endpoints.Orders;

public class CreateOrderEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/orders", async (ISender mediator, [FromBody] CreateOrderCommand command) =>
            {
                var newOrder = await mediator.Send(command);

                return Results.Created($"/api/orders/{newOrder}", new { Id = newOrder });
            })
            .WithName("CreateOrderEndpoint")
            .WithTags("Orders");
    }
}