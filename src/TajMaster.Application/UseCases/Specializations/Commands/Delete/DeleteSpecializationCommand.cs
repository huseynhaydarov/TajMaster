using MediatR;
using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.Specializations.Commands.Delete;

public record DeleteSpecializationCommand(Guid SpecializationId) : ICommand<Unit>;