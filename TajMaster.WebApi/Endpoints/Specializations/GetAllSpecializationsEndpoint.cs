using Carter;
using MediatR;
using TajMaster.Application.UseCases.Specializations.Queries.GetAll;

namespace TajMaster.WebApi.Endpoints.Specializations;

public class GetAllSpecializationsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/specializations", async (ISender mediator) =>
        {
            var specializations = await mediator.Send(new GetAllSpecializationsQuery());
            
            return Results.Ok(specializations);
        })
            .WithName("GetAllSpecializationsEndpoint")
            .WithTags("Specializations");
    }
}