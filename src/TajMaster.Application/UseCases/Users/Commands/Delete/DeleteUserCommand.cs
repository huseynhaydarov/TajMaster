using MediatR;
using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.Users.Commands.Delete;

public record DeleteUserCommand(Guid UserId) : ICommand<Unit>;