using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Reviews.Commands.Delete;

namespace TajMaster.WebApi.Endpoints.Reviews;

public class DeleteReviewEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/reviews/{id:guid}", async (ISender mediator, [FromRoute] Guid id, 
                CancellationToken cancellationToken) =>
            {
                await mediator.Send(new DeleteReviewCommand(id), cancellationToken);

                return Results.NoContent();
            })
            .RequireAuthorization("CustomerPolicy")
            .WithName("DeleteReviewEndpoint")
            .WithTags("Reviews");
    }
}