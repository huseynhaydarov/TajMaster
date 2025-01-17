using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.CartStatuses.Command.Update;

namespace TajMaster.WebApi.Endpoints.CartStatuses;

public class UpdateCartStatusEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/api/cart-statuses/{id:guid}", async (ISender mediator, Guid id, [FromBody] UpdateCartStatusCommand command) =>
            {

                if (id != command.CartStatusId)
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
            .WithName("UpdateCartStatusEndpoint")
            .WithTags("CartStatuses");
    }
}