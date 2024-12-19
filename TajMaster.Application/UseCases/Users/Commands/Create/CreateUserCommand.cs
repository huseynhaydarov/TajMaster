using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Domain.Enums;

namespace TajMaster.Application.UseCases.Users.Commands.Create;

public record CreateUserCommand(
    string FullName,
    string? Email,
    string HashedPassword,
    string Phone,
    Role Roles,
    DateTime RegisterDate,
    string? ProfilePicture,
    bool IsVerified,
    bool IsActive)
    : ICommand<int>;