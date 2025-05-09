using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Interfaces.PasswordHasher;
using TajMaster.Application.Common.Interfaces.TokenService;
using TajMaster.Application.UseCases.Auths.AuthDtos;

namespace TajMaster.Application.UseCases.Auths.Commands;

public class LoginCommandHandler(
    IApplicationDbContext context,
    ITokenService tokenService,
    IPasswordHasher passwordHasher)
    : IRequestHandler<LoginCommand, AuthResponse>
{
    public async Task<AuthResponse> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .Include(u => u.UserRole)
            .FirstOrDefaultAsync(u => u.Email == command.Email, cancellationToken);

        if (user == null) return UnauthorizedResponse("Invalid credentials");

        try
        {
            if (!passwordHasher.VerifyHash(command.Password, user.HashedPassword))
                return UnauthorizedResponse("Invalid credentials");
        }
        catch (ArgumentException)
        {
            return UnauthorizedResponse("Invalid credentials");
        }

        if (!user.IsActive) return UnauthorizedResponse("Account is not active");

        var token = tokenService.GenerateJwtToken(user);

        var refreshToken = tokenService.GenerateRefreshToken();

        return new AuthResponse(
            true,
            token,
            refreshToken,
            user.FullName,
            user.Email,
            user.UserRole.Name);
     }

    private static AuthResponse UnauthorizedResponse(string errorMessage)
    {
        return new AuthResponse(
            false,
            string.Empty,
            string.Empty,
            Errors: [errorMessage]);
    }
}