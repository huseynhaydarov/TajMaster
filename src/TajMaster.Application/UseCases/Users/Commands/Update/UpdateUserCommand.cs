using MediatR;
using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.Users.Commands.Update;

public record UpdateUserCommand(
    string? FullName,
    string? Email,
    string? Phone,
    string? Address) : ICommand<Unit>;