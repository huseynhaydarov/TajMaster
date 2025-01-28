using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Orders.Commands.Create;

namespace TajMaster.WebApi.Endpoints.Orders;

public class CreateOrderEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/orders", async ([FromBody] CreateOrderCommand command, 
                ISender mediator) =>
            {
                var newOrder = await mediator.Send(command);

                return Results.Created($"/api/orders/{newOrder}", new { Id = newOrder });
            })
            .RequireAuthorization("CustomerPolicy")
            .WithName("CreateOrderEndpoint")
            .WithTags("Orders");
    }
}