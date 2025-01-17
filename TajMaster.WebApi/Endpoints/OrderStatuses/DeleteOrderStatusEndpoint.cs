using Carter;
using MediatR;
using TajMaster.Application.UseCases.CartStatuses.Command.Delete;
using TajMaster.Application.UseCases.OrderStatuses.Commands.Delete;

namespace TajMaster.WebApi.Endpoints.OrderStatuses;

public class DeleteCartStatusEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/order-statuses/{id:guid}", async (ISender mediator, Guid id) =>
            {
                var command = new DeleteOrderStatusCommand(id);
                var result = await mediator.Send(command);
                
                if (result)
                {
                    return Results.NoContent();
                } 
                
                return Results.NotFound(); 
            })
            .WithName("DeleteOrderStatusEndpoint")
            .WithTags("OrderStatuses");
    }
}