using Carter;
using MediatR;
using TajMaster.Application.UseCases.Craftsmen.Commands.Create.CompleteCraftsmanProfile;

namespace TajMaster.WebApi.Endpoints.Craftsmen;

public class CompleteCraftsmanProfileEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/craftsmen", async (HttpContext context, ISender mediator) =>
            {
                var form = await context.Request.ReadFormAsync();

                var command = new CompleteCraftsmanProfileCommand(
                    Guid.Parse(form["userId"]!),
                    form["specialization"].ToString(),
                    int.Parse(form["experience"]!),
                    form["about"].ToString(),
                    form.Files.GetFile("profilePicture")
                );

                var newCraftsman = await mediator.Send(command);

                return Results.Created($"api/craftsmen/{newCraftsman}", new { Id = newCraftsman });
            })
            .RequireAuthorization("AdminPolicy")
            .WithName("CompleteCraftsmanProfileEndpoint")
            .WithTags("Craftsmen")
            .Accepts<CompleteCraftsmanProfileCommand>("multipart/form-data")
            .Produces<int>(201)
            .Produces(400)
            .DisableAntiforgery();
    }
}