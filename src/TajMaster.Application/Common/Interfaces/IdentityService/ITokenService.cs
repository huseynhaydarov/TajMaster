using System.Security.Claims;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.Common.Interfaces.IdentityService;

public interface ITokenService
{
    string GenerateJwtToken(User user);
    string GenerateRefreshToken();
    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
}