using Microsoft.AspNetCore.Http;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Domain.Enums;

namespace TajMaster.Application.UseCases.Users.Commands.Create;

public record CreateUserCommand(
    string FullName,
    string? Email,
    string HashedPassword,
    string? Address,
    string Phone)
    : ICommand<int>;