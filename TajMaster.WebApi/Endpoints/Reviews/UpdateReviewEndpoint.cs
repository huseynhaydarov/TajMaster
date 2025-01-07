using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Reviews.Commands.Update;

namespace TajMaster.WebApi.Endpoints.Reviews;

public class UpdateReviewEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/api/reviews/{id}", async (ISender mediator, int id, [FromBody] UpdateReviewCommand command) =>
            {
                if (id != command.ReviewId) return Results.BadRequest();
                var result = await mediator.Send(command);
                return result ? Results.NoContent() : Results.NotFound();
            })
            .WithName("UpdateReviewEndpoint")
            .WithTags("Reviews");
    }
}