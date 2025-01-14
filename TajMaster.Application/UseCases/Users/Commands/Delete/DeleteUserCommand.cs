using MediatR;

namespace TajMaster.Application.UseCases.Users.Commands.Delete;

public record DeleteUserCommand(Guid UserId) : IRequest<bool>;