using MediatR;

namespace TajMaster.Application.UseCases.Craftsmen.Commands.Delete;

public record DeleteCraftsmanCommand(Guid CraftsmanId) : IRequest<bool>;