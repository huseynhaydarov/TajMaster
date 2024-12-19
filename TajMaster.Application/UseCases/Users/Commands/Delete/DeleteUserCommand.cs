using MediatR;

namespace TajMaster.Application.UseCases.Users.Commands.Delete;

public record DeleteUserCommand(int UserId) : IRequest<bool>;