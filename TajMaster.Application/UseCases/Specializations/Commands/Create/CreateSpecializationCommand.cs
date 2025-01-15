using MediatR;

namespace TajMaster.Application.UseCases.Specializations.Command.Create;

public record CreateSpecializationCommand(string Name, string? Description) : IRequest<Guid>;