using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.CartStatuses.Command.Create;
using TajMaster.Application.UseCases.OrderStatuses.Commands.Create;

namespace TajMaster.WebApi.Endpoints.OrderStatuses;

public class CreateCartStatusEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/order-statuses", async (ISender mediator, 
                [FromBody] CreateOrderStatusCommand command) =>
            {
                var newOrderStatus = await mediator.Send(command);
                
                return Results.Created($"/api/order-statuses/{newOrderStatus}", new { Id = newOrderStatus });
            })
            .WithName("CreateOrderStatusEndpoint")
            .WithTags("OrderStatuses");
    }
}