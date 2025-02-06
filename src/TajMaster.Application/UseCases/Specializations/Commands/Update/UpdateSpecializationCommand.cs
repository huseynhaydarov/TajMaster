using MediatR;
using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.Specializations.Commands.Update;

public record UpdateSpecializationCommand(
    Guid SpecializationId, string Name, string? Description) : ICommand<Unit>;