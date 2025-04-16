using Carter;
using MediatR;
using TajMaster.Application.UseCases.Services.Queries.GetService;

namespace TajMaster.WebApi.Endpoints.Services;

public class GetServiceByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/services/{id:guid}", async (Guid id, ISender mediator, 
                CancellationToken cancellationToken) =>
            {
                var user = await mediator.Send(new GetServiceByIdQuery(id), cancellationToken);

                return Results.Ok(user);
            })
            .RequireAuthorization("AdminOrCustomerPolicy")
            .WithName("GetServiceByIdEndpoint")
            .WithTags("Services");
    }
}