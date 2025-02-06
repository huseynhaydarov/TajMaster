using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Reviews.Commands.Update;

namespace TajMaster.WebApi.Endpoints.Reviews;

public class UpdateReviewEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/api/reviews/{id:guid}",
                async (Guid id, [FromBody] UpdateReviewCommand command, ISender mediator, 
                    CancellationToken cancellationToken) =>
                {
                    if (id != command.ReviewId)
                    {
                        return Results.BadRequest();
                    }

                    await mediator.Send(command, cancellationToken);

                    return Results.NoContent();
                })
            .RequireAuthorization("AdminOrCraftsmanPolicy")
            .WithName("UpdateReviewEndpoint")
            .WithTags("Reviews");
    }
}