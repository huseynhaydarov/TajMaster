using Carter;
using MediatR;
using TajMaster.Application.UseCases.Craftsmen.CraftsmanDtos;
using TajMaster.Application.UseCases.Craftsmen.Queries.GetCraftsmanByUser;
using TajMaster.Application.Exceptions;

namespace TajMaster.WebApi.Endpoints.Craftsmen;

public class GetCraftsmenByUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/craftsmen/user", 
                async (ISender sender, CancellationToken cancellationToken) =>
                {
                    try
                    {
                        var query = new GetCraftsmanByUserQuery();
                        var craftsman = await sender.Send(query, cancellationToken);

                        return Results.Ok(craftsman);
                    }
                    catch (NotFoundException ex)
                    {
                        return Results.NotFound(ex.Message);
                    }
                })
            .RequireAuthorization("AdminOrCraftsmanPolicy")
            .WithName("GetCraftsmanByUserEndpoint")
            .Produces<CraftsmanDto>()
            .Produces(StatusCodes.Status404NotFound)
            .WithTags("Craftsmen");
    }
}