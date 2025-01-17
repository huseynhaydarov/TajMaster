using Carter;
using MediatR;
using TajMaster.Application.UseCases.Reviews.Queries.GetReviewsByUser;
using TajMaster.Application.UseCases.Reviews.ReviewDtos;

namespace TajMaster.WebApi.Endpoints.Reviews;

public class GetReviewsByUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/reviews/user/{Id:guid}", async (Guid userId, ISender sender) =>
            {
                if (userId == Guid.Empty)
                {
                    return Results.BadRequest(new { Message = "Invalid user ID." });
                }

                var query = new GetReviewsByCustomerIdQuery(userId);

                var reviews = await sender.Send(query);

                var reviewDto = reviews as ReviewDto[] ?? reviews.ToArray();
                
                if (!reviewDto.Any())
                {
                    return Results.NotFound(new { Message = $"No reviews found for user ID {userId}." });
                }

                return Results.Ok(reviewDto);
            })
            .WithName("GetReviewsByUserEndpoint")
            .WithTags("Reviews")
            .Produces<IEnumerable<ReviewDto>>();
    }
}