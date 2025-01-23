using Carter;
using MediatR;
using TajMaster.Application.UseCases.Reviews.Queries.GetReviewsByCraftsman;
using TajMaster.Application.UseCases.Reviews.ReviewDtos;

namespace TajMaster.WebApi.Endpoints.Reviews;

public class GetReviewsByCraftsman : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/reviews/craftsman/{Id:guid}", async (Guid craftsmanId, ISender sender) =>
            {
                if (craftsmanId == Guid.Empty) return Results.BadRequest(new { Message = "Invalid craftsman ID." });

                var query = new GetReviewsByCraftsmanIdQuery(craftsmanId);

                var reviews = await sender.Send(query);

                var reviewDto = reviews as ReviewDto[] ?? reviews.ToArray();

                if (!reviewDto.Any())
                    return Results.NotFound(new { Message = $"No reviews found for craftsman ID {craftsmanId}." });

                return Results.Ok(reviewDto);
            })
            .RequireAuthorization("AdminOrCraftsmanPolicy")
            .WithName("GetReviewsByCraftsmanEndpoint")
            .WithTags("Reviews")
            .Produces<IEnumerable<ReviewDto>>();
    }
}