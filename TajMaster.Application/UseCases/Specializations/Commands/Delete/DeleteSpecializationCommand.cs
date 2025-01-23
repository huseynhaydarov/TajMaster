using MediatR;

namespace TajMaster.Application.UseCases.Specializations.Commands.Delete;

public record DeleteSpecializationCommand(Guid SpecializationId) : IRequest<bool>;