using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Craftsmen.CraftsmanDtos;
using TajMaster.Application.UseCases.Craftsmen.Queries.GetCraftsmenBySpecialization;

namespace TajMaster.WebApi.Endpoints.Craftsmen;

public class GetCraftsmenBySpecializationEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/craftsmen/specialization/{specialization}", async (
                [FromRoute] string specialization,
                ISender mediator, CancellationToken cancellationToken) =>
            {
                var craftsmen = await mediator
                    .Send(new GetCraftsmenBySpecializationQuery(specialization), cancellationToken);

                return craftsmen.Any()
                    ? Results.Ok(craftsmen)
                    : Results.NotFound(new { Message = "No craftsmen found for this specialization." });
            })
            .AllowAnonymous()
            .WithName("GetCraftsmenBySpecialization")
            .WithTags("Craftsmen")
            .Produces<List<CraftsmanDto>>()
            .WithTags("Craftsmen");
    }
}