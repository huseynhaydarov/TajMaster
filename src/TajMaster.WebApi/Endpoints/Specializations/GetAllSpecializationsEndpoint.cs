using Carter;
using MediatR;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.Specializations.Queries.GetAll;

namespace TajMaster.WebApi.Endpoints.Specializations;

public class GetAllSpecializationsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/specializations", async ([AsParameters] PagingParameters pagingParameters, 
                ISender mediator) =>
            {
                var specializations = await mediator
                    .Send(new GetAllSpecializationsQuery(pagingParameters));

                return Results.Ok(specializations);
            })
            .RequireAuthorization("AdminPolicy")
            .WithName("GetAllSpecializationsEndpoint")
            .WithTags("Specializations");
    }
}