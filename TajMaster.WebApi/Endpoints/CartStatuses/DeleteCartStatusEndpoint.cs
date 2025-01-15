using Carter;
using MediatR;
using TajMaster.Application.UseCases.CartStatus.Command.Delete;

namespace TajMaster.WebApi.Endpoints.CartStatuses;

public class DeleteCartStatusEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/cart-statuses/{id:guid}", async (ISender mediator, Guid id) =>
            {
                var command = new DeleteCartStatusCommand(id);
                var result = await mediator.Send(command);

                if (result)
                    return Results.NoContent();  // Return 204 No Content on successful deletion

                return Results.NotFound();  // Return 404 if CartStatus not found
            })
            .WithName("DeleteCartStatusEndpoint")
            .WithTags("CartStatuses");
    }
}