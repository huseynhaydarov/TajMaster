using Carter;
using MediatR;
using TajMaster.Application.UseCases.Reviews.Queries.GetReview;

namespace TajMaster.WebApi.Endpoints.Reviews;

public class GetReviewByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/reviews/{id}", async (ISender mediator, int id) =>
            {
                var review = await mediator.Send(new GetReviewByIdQuery(id));
                return Results.Ok(review);
            })
            .WithName("GetReviewByIdEndpoint")
            .WithTags("Reviews");
    }
}