using Carter;
using MediatR;
using TajMaster.Application.UseCases.Services.Queries.GetService;

namespace TajMaster.WebApi.Endpoints.Reviews;

public class GetReviewByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/reviews/{id}", async (ISender mediator, int id) =>
            {
                var review = await mediator.Send(new GetServiceByIdQuery(id));
                return Results.Ok(review);
            })
            .WithName("GetReviewByIdEndpoint");
    }
}