using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Reviews.Commands.Create;

namespace TajMaster.WebApi.Endpoints.Reviews;

public class CreateReviewEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/reviews", async ([FromBody] CreateReviewCommand command, ISender mediator) =>
            {
                var newReview = await mediator.Send(command);

                return Results.Created($"/api/reviews/{newReview}", new { id = newReview });
            })
            .RequireAuthorization("CustomerPolicy")
            .WithName("CreateReviewEndpoint")
            .WithTags("Reviews");
    }
}