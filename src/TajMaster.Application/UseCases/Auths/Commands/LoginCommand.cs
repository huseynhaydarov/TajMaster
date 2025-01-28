using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.Auths.AuthDtos;

namespace TajMaster.Application.UseCases.Auths.Commands;

public record LoginCommand : ICommand<AuthResponse>
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}