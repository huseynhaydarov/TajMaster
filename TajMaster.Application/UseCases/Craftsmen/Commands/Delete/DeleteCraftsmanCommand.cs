using MediatR;

namespace TajMaster.Application.UseCases.Craftsmen.Commands.Delete;

public record DeleteCraftsmanCommand(int CraftsmenId) : IRequest<bool>;