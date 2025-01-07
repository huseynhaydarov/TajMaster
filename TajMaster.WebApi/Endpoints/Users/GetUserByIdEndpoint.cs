using Carter;
using MediatR;
using TajMaster.Application.UseCases.Users.Queries.GetUser;
using TajMaster.Application.UseCases.Users.UserDtos;

namespace TajMaster.WebApi.Endpoints.Users;

public class GetUserByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/users/{id}", async (ISender mediator, int id) =>
            {
                var user = await mediator.Send(new GetUserByIdQuery(id));
                return Results.Ok(user);
            })
            .WithName("GetUserByIdEndpoint")
            .WithTags("Users")
            .Produces<UserSummaryDto>();
    }
}