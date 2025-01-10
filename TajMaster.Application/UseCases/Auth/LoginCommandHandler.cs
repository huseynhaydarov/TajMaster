using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Interfaces.IdentityService;
using TajMaster.Application.Common.Interfaces.PasswordHasher;
using TajMaster.Application.UseCases.Auth.AuthDTOs;

namespace TajMaster.Application.UseCases.Auth;

public class LoginCommandHandler(
    IUnitOfWork unitOfWork,
    ITokenService tokenService,
    IPasswordHasher passwordHasher)
    : IRequestHandler<LoginCommand, AuthResponse>
{
    public async Task<AuthResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.UserRepository.GetByEmailAsync(request.Email);
        if (user == null)
        {
            return UnauthorizedResponse("Invalid credentials");
        }
        
        try
        {
            if (passwordHasher.VerifyHash(request.Password, user.HashedPassword))
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
            user.Roles);
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
