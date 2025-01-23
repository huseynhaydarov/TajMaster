using Carter;
using MediatR;
using TajMaster.Application.UseCases.Craftsmen.CraftsmanDTos;
using TajMaster.Application.UseCases.Craftsmen.Queries.GetCraftsmanByUser;

namespace TajMaster.WebApi.Endpoints.Craftsmen;

public class GetCraftsmenByUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/craftsmen/user/{userId:guid}", async (Guid userId, ISender sender) =>
            {
                if (userId == Guid.Empty)
                    return Results.BadRequest(new { Message = "UserId must be a positive integer." });

                var query = new GetCraftsmanByUserIdQuery(userId);

                var craftsmen = await sender.Send(query);

                return Results.Ok(craftsmen );
            })
            .WithName("GetCraftsmenByUserEndpoint")
            .Produces<IEnumerable<CraftsmanDto>>()
            .WithTags("Craftsmen");
    }
}