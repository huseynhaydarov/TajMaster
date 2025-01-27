using MediatR;
using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.Craftsmen.Commands.Delete;

public record DeleteCraftsmanCommand(Guid CraftsmanId) : ICommand<Unit>;