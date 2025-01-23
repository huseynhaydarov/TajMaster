using Carter;
using MediatR;
using TajMaster.Application.UseCases.Specializations.Queries.GetById;

namespace TajMaster.WebApi.Endpoints.Specializations;

public class GetSpecializationByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/specializations/{id:guid}", async (ISender mediator, Guid id) =>
            {
                var specialization = await mediator.Send(new GetSpecializationByIdQuery(id));

                return Results.Ok(specialization);
            })
            .RequireAuthorization("AdminPolicy")
            .WithName("GetSpecializationByIdEndpoint")
            .WithTags("Specializations");
    }
}