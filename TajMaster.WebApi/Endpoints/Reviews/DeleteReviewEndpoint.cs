using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Reviews.Commands.Delete;

namespace TajMaster.WebApi.Endpoints.Reviews;

public class DeleteReviewEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/reviews/{id:guid}", async (ISender mediator, [FromRoute] Guid id) =>
            {
                var result = await mediator.Send(new DeleteReviewCommand(id));
                
                return result ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteReviewEndpoint")
            .WithTags("Reviews");
    }
}