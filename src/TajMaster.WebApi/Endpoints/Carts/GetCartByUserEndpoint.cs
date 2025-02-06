using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Carts.Queries;

namespace TajMaster.WebApi.Endpoints.Carts;

public class GetCartByUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/carts/{userId:guid}", async ([FromRoute] Guid userId, 
                ISender mediator, CancellationToken cancellationToken) =>
            {
                var cart = await mediator.Send(new GetCartByUserIdQuery(userId), cancellationToken);
                
                return Results.Ok(cart);
            })
            .RequireAuthorization("CustomerPolicy")
            .WithName("GetCartEndpoint")
            .WithTags("Carts");
    }
}