using Carter;
using MediatR;
using TajMaster.Application.UseCases.Specializations.Commands.Delete;

namespace TajMaster.WebApi.Endpoints.Specializations;

public class DeleteSpecializationEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        // Delete Specialization
        app.MapDelete("/api/specializations/{id}", async (ISender mediator, Guid id) =>
        {
            var result = await mediator.Send(new DeleteSpecializationCommand(id));
            return result ? Results.NoContent() : Results.NotFound($"Specialization with id {id} not found.");
        }).WithName("DeleteSpecialization");
    }
}