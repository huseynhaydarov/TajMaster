using Carter;
using MediatR;
using TajMaster.Application.UseCases.DTO;
using TajMaster.Application.UseCases.Reviews.Queries.GetReviewsByCraftsman;

namespace TajMaster.WebApi.Endpoints.Reviews;

public class GetReviewsByCraftsman : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/reviews/craftsman/{Id}", async (int craftsmanId, ISender sender) =>
            {
                if (craftsmanId <= 0)
                    return Results.BadRequest(new { Message = "CraftsmanId must be a positive integer." });

                var query = new GetReviewsByCraftsmanIdQuery(craftsmanId);

                var reviews = await sender.Send(query);

                var reviewDto = reviews as ReviewDto[] ?? reviews.ToArray();
                if (!reviewDto.Any())
                    return Results.NotFound(new { Message = $"No reviews found for craftsman ID {craftsmanId}." });

                return Results.Ok(reviewDto);
            })
            .WithName("GetReviewsByCraftsmanEndpoint")
            .Produces<IEnumerable<ReviewDto>>();
    }
}