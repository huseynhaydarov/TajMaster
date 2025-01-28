using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.Specializations.Commands.Create;

public record CreateSpecializationCommand(string Name, string? Description) : ICommand<Guid>;