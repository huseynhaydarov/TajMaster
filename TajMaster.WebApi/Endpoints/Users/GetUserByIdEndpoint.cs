using Carter;
using MediatR;
using TajMaster.Application.UseCases.Users.Queries.GetUser;
using TajMaster.Application.UseCases.Users.UserDtos;

namespace TajMaster.WebApi.Endpoints.Users;

public class GetUserByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/users/{id:guid}", async (ISender mediator, Guid id) =>
            {
                var user = await mediator.Send(new GetUserByIdQuery(id));
                
                return Results.Ok(user);
            })
            .WithName("GetUserByIdEndpoint")
            .WithTags("Users")
            .Produces<UserSummaryDto>();
    }
}