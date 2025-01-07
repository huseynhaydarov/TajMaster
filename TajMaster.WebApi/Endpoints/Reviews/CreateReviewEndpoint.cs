using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Reviews.Commands.Create;

namespace TajMaster.WebApi.Endpoints.Reviews;

public class CreateReviewEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/reviews", async (ISender mediator, [FromBody] CreateReviewCommand command) =>
        {
            var reviewId = await mediator.Send(command);
            return Results.Created($"/reviews/{reviewId}", new { id = reviewId });
        })
            .WithName("CreateReviewEndpoint")
            .WithTags("Reviews");
    }
}