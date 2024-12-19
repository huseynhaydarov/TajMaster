using Carter;
using MediatR;
using TajMaster.Application.UseCases.Users.Queries.GetUser;

namespace TajMaster.WebApi.Endpoints.Users;

public class GetUserByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/users/{id}", async (ISender mediator, int id) =>
            {
                var user = await mediator.Send(new GetUserByIdQuery(id));
                return Results.Ok(user);
            })
            .WithName("GetUserByIdEndpoint");
    }
}