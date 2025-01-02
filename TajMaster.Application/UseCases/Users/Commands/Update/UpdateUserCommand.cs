using MediatR;
using TajMaster.Domain.Enums;

namespace TajMaster.Application.UseCases.Users.Commands.Update;

public record UpdateUserCommand(
    int UserId,
    string FullName,
    string? Email,
    string Phone,
    string? Address,
    string? ProfilePicture)
    : IRequest<bool>;