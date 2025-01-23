using Carter;
using MediatR;
using TajMaster.Application.UseCases.Services.Queries.GetService;

namespace TajMaster.WebApi.Endpoints.Services;

public class GetServiceByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/services/{id:guid}", async (ISender mediator, Guid id) =>
            {
                var user = await mediator.Send(new GetServiceByIdQuery(id));

                return Results.Ok(user);
            })
            .WithName("GetServiceByIdEndpoint")
            .WithTags("Services");
    }
}