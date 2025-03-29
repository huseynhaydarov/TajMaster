using Carter;
using MediatR;
using TajMaster.Application.UseCases.Reviews.Queries.GetReviewsByUser;
using TajMaster.Application.UseCases.Reviews.ReviewDtos;

namespace TajMaster.WebApi.Endpoints.Reviews;

public class GetReviewsByUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/reviews/user", async (Guid userId, 
                ISender sender, CancellationToken cancellationToken) =>
            {
                if (userId == Guid.Empty)
                {
                    return Results.BadRequest();
                }

                var query = new GetReviewsByCustomerQuery();

                var reviews = await sender.Send(query, cancellationToken);

                var reviewDto = reviews as ReviewDto[] ?? reviews.ToArray();

                if (!reviewDto.Any())
                {
                    return Results.NotFound();
                }

                return Results.Ok(reviewDto);
            })
            .RequireAuthorization("AdminOrCustomerPolicy")
            .WithName("GetReviewsByUserEndpoint")
            .WithTags("Reviews")
            .Produces<IEnumerable<ReviewDto>>();
    }
}