using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.Common.Interfaces.IdentityService;
using TajMaster.Application.UseCases.Carts.Queries;

namespace TajMaster.WebApi.Endpoints.Carts;

public class GetCartByUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/carts/user", async (ISender mediator, CancellationToken cancellationToken) =>
            {
                var cart = await mediator.Send(new GetCartByUserQuery(), cancellationToken);
                
                return Results.Ok(cart);
            })
            .RequireAuthorization("CustomerPolicy")
            .WithName("GetCartEndpoint")
            .WithTags("Carts");
    }
}