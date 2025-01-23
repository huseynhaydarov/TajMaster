using MediatR;

namespace TajMaster.Application.UseCases.Specializations.Commands.Update;

public record UpdateSpecializationCommand(Guid SpecializationId, string Name, string? Description) 
    : IRequest<bool>;