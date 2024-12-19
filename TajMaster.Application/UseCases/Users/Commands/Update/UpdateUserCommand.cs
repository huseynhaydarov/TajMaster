using MediatR;
using TajMaster.Domain.Enums;

namespace TajMaster.Application.UseCases.Users.Commands.Update;

public record UpdateUserCommand(
    int UserId,
    string FullName,
    string? Email,
    string HashedPassword,
    string Phone,
    Role Roles,
    DateTime RegisterDate,
    string? ProfilePicture,
    bool IsVerified,
    bool IsActive)
    : IRequest<bool>;