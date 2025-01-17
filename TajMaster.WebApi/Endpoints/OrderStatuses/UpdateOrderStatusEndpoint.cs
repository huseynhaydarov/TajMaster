using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.OrderStatuses.Commands.Update;

namespace TajMaster.WebApi.Endpoints.OrderStatuses;

public class UpdateCartStatusEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/api/order-statuses/{id:guid}", async (ISender mediator, Guid id, 
                [FromBody] UpdateOrderStatusCommand command) =>
            {

                if (id != command.OrderStatusId)
                {
                    return Results.NotFound();
                }
                var result = await mediator.Send(command);

                if (result)
                {
                    return Results.NoContent();
                }

                return Results.NotFound(); 
            })
            .WithName("UpdateOrderStatusEndpoint")
            .WithTags("OrderStatuses");
    }
}