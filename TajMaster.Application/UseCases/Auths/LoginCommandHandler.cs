using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Interfaces.IdentityService;
using TajMaster.Application.Common.Interfaces.PasswordHasher;
using TajMaster.Application.UseCases.Auth;
using TajMaster.Application.UseCases.Auths.AuthDTOs;

namespace TajMaster.Application.UseCases.Auths;

public class LoginCommandHandler(
   IApplicationDbContext context,
    ITokenService tokenService,
    IPasswordHasher passwordHasher)
    : IRequestHandler<LoginCommand, AuthResponse>
{
    public async Task<AuthResponse> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        var user = await context.Users.FirstOrDefaultAsync(l => l.Email == command.Email, cancellationToken);
        
        if (user == null)
        {
            return UnauthorizedResponse("Invalid credentials");
        }
        
        try
        {
            if (passwordHasher.VerifyHash(command.Password, user.HashedPassword))
            {
                return UnauthorizedResponse("Invalid credentials");
            }
        }
        catch (ArgumentException)
        {
            return UnauthorizedResponse("Invalid credentials");
        }
        
        if (!user.IsActive)
        {
            return UnauthorizedResponse("Account is not active");
        }
        
        var token = tokenService.GenerateJwtToken(user);
        
        var refreshToken = tokenService.GenerateRefreshToken();
        
        return new AuthResponse(
            true,
            token,
            refreshToken,
            user.FullName,
            user.Email,
            user.UserRole);
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
