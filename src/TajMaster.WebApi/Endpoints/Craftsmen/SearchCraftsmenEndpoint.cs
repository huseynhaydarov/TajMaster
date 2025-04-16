using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Craftsmen.Queries.SearchCraftsmen;

namespace TajMaster.WebApi.Endpoints.Craftsmen;

public class SearchCraftsmenEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/craftsmen/search", async (
                [FromQuery] string? specialization,
                [FromQuery] bool? availability,
                [FromQuery] bool? profileVerified,
                [FromQuery] int? minExperience,
                [FromQuery] int? minRating,
                ISender mediator,
                CancellationToken cancellationToken
            ) =>
            {
                var query = new SearchCraftsmenQuery(
                    specialization,
                    availability,
                    profileVerified,
                    minExperience,
                    minRating
                );

                var craftsmen = await mediator.Send(query, cancellationToken);
                return Results.Ok(craftsmen);
            })
            .AllowAnonymous()
            .WithName("SearchCraftsmen")
            .WithTags("Craftsmen");
    }
}