using Carter;
using MediatR;
using TajMaster.Application.UseCases.Craftsmen.Commands.Create;

namespace TajMaster.WebApi.Endpoints.Craftsmen;

public class CreateCraftsmanEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/craftsmen", async (HttpContext context, ISender mediator) =>
            {
                var form = await context.Request.ReadFormAsync();

                var command = new CreateCraftsmanCommand(
                    int.Parse(form["userId"]!),
                    int.Parse(form["specialization"].ToString()!),
                    int.Parse(form["experience"]!),
                    form["about"].ToString(),
                    form.Files.GetFile("profilePicture")
                );

                var craftsmanId = await mediator.Send(command);
                return Results.Created($"/craftsmen/{craftsmanId}", new { Id = craftsmanId });
            })
            .WithName("CreateCraftsmanEndpoint")
            .WithTags("Craftsmen")
            .Accepts<CreateCraftsmanCommand>("multipart/form-data")
            .Produces<int>(201)
            .Produces(400)
            .DisableAntiforgery();
    }
}