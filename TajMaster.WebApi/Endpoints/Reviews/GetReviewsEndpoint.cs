using Carter;
using MediatR;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.DTO;
using TajMaster.Application.UseCases.Reviews.Queries.GetReviews;
using TajMaster.Application.UseCases.Services.Queries;

namespace TajMaster.WebApi.Endpoints.Reviews;

public class GetReviewsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/reviews", async ([AsParameters] PagingParameters pagingParameters, ISender mediator) =>
            {
                var results = await mediator.Send(new GetReviewsQuery(pagingParameters));

                return Results.Ok(results);
            })
            .WithName("GetReviewsEndpoint")
            .Produces<PaginatedResult<ReviewDto>>();
    }
}