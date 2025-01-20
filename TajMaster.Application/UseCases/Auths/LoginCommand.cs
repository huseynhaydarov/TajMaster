using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.Auths.AuthDTOs;

namespace TajMaster.Application.UseCases.Auth;

public record LoginCommand : ICommand<AuthResponse>
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}
