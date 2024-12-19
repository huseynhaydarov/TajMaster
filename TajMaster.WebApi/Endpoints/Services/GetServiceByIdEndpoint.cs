using Carter;
using MediatR;
using TajMaster.Application.UseCases.Services.Queries.GetService;

namespace TajMaster.WebApi.Endpoints.Services;

public class GetServiceByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/services/{id}", async (ISender mediator, int id) =>
            {
                var user = await mediator.Send(new GetServiceByIdQuery(id));
                return Results.Ok(user);
            })
            .WithName("GetServiceByIdEndpoint");
    }
}