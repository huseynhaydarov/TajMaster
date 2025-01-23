using MediatR;

namespace TajMaster.Application.UseCases.Specializations.Commands.Create;

public record CreateSpecializationCommand(string Name, string? Description) : IRequest<Guid>;