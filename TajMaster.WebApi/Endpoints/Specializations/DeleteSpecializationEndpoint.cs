using Carter;
using MediatR;
using TajMaster.Application.UseCases.Specializations.Commands.Delete;

namespace TajMaster.WebApi.Endpoints.Specializations;

public class DeleteSpecializationEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/specializations/{id:guid}", async (ISender mediator, Guid id) =>
        {
            var result = await mediator.Send(new DeleteSpecializationCommand(id));
           
            return result ? Results.NoContent() : Results.NotFound();
        })
            .WithName("DeleteSpecializationEndpoint")
            .WithTags("Specializations");
    }
}