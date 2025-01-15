using Carter;
using MediatR;
using TajMaster.Application.UseCases.Specializations.Queries.GetById;

namespace TajMaster.WebApi.Endpoints.Specializations;

public class GetSpecializationByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        // Get Specific Specialization by Id
        app.MapGet("/api/specializations/{id}", async (ISender mediator, Guid id) =>
        {
            var specialization = await mediator.Send(new GetSpecializationByIdQuery(id));
            return Results.Ok(specialization);
        }).WithName("GetSpecializationById");
    }
}