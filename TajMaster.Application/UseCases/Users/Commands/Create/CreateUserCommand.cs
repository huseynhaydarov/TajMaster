using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.Users.Commands.Create;

public record CreateUserCommand(
    string FullName,
    string? Email,
    string HashedPassword,
    string? Address,
    string Phone)
    : ICommand<int>;