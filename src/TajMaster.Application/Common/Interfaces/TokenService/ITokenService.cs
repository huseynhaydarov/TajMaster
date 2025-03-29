using System.Security.Claims;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.Common.Interfaces.TokenService;

public interface ITokenService
{
    string GenerateJwtToken(User user);
    string GenerateRefreshToken();
    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
}