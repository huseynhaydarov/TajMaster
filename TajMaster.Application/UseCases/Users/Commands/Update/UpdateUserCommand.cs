using MediatR;

namespace TajMaster.Application.UseCases.Users.Commands.Update;

public record UpdateUserCommand(
    Guid UserId,
    string FullName,
    string? Email,
    string Phone,
    string? Address)
    : IRequest<bool>;