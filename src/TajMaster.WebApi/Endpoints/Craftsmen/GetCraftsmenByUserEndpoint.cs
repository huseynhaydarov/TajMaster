using Carter;
using MediatR;
using TajMaster.Application.UseCases.Craftsmen.CraftsmanDtos;
using TajMaster.Application.UseCases.Craftsmen.Queries.GetCraftsmanByUser;

namespace TajMaster.WebApi.Endpoints.Craftsmen;

public class GetCraftsmenByUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/craftsmen/user/{userId:guid}", async (Guid userId, 
                ISender sender, CancellationToken cancellationToken) =>
            {
                if (userId == Guid.Empty)
                {
                    return Results.BadRequest();
                }

                var query = new GetCraftsmanByUserIdQuery(userId);

                var craftsmen = await sender.Send(query, cancellationToken);

                return Results.Ok(craftsmen );
            })
            .RequireAuthorization("AdminOrCraftsmanPolicy")
            .WithName("GetCraftsmenByUserEndpoint")
            .Produces<IEnumerable<CraftsmanDto>>()
            .WithTags("Craftsmen");
    }
}