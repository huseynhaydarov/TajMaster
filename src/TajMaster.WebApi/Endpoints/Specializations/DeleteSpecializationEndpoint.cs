using Carter;
using MediatR;
using TajMaster.Application.UseCases.Specializations.Commands.Delete;

namespace TajMaster.WebApi.Endpoints.Specializations;

public class DeleteSpecializationEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/specializations/{id:guid}", async (Guid id, ISender mediator, 
                CancellationToken cancellationToken) =>
            { 
                await mediator.Send(new DeleteSpecializationCommand(id), cancellationToken);

                Results.NoContent();
            })
            .RequireAuthorization("AdminPolicy")
            .WithName("DeleteSpecializationEndpoint")
            .WithTags("Specializations");
    }
}