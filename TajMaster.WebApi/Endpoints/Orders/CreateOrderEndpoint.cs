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
                var orderId = await mediator.Send(command);
                return Results.Created($"/orders/{orderId}", new { Id = orderId });
            })
            .WithName("CreateOrderEndpoint")
            .WithTags("Orders");
    }
}