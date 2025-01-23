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
                async (ISender mediator, Guid id, [FromBody] UpdateReviewCommand command) =>
                {
                    if (id != command.ReviewId) return Results.BadRequest(new { message = "Review id mismatch." });

                    var result = await mediator.Send(command);

                    return result ? Results.NoContent() : Results.NotFound();
                })
            .RequireAuthorization("AdminOrCraftsmanPolicy")
            .WithName("UpdateReviewEndpoint")
            .WithTags("Reviews");
    }
}