using System.Security.Claims;
using TajMaster.Application.Common.Interfaces.IdentityService;

namespace TajMaster.WebApi.Services;

public class AuthenticatedUserService : IAuthenticatedUserService
{
    private string? _data;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        _data = httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == "data")?.Value;
    }

    public Guid? UserId
    {
        get
        {
            var userIdString = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Guid.TryParse(userIdString, out var userId) ? userId : Guid.Empty;
        }
    }

    public string? UserName => _httpContextAccessor.HttpContext?.User?.Identity?.Name;
    public string? Email => _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;
    public IEnumerable<string> Roles => _httpContextAccessor.HttpContext?.User?.Claims
        .Where(c => c.Type == ClaimTypes.Role)
        .Select(c => c.Value) ?? [];
}