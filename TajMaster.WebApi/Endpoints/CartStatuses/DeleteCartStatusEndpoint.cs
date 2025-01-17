using Carter;
using MediatR;
using TajMaster.Application.UseCases.CartStatuses.Command.Delete;

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
                {
                    return Results.NoContent();
                } 
                
                return Results.NotFound(); 
            })
            .WithName("DeleteCartStatusEndpoint")
            .WithTags("CartStatuses");
    }
}