namespace TajMaster.Application.Common.Interfaces.IdentityService;

public interface IAuthenticatedUserService
{
    Guid? UserId { get; }
    string? UserName { get; }
    string? Email { get; }
    IEnumerable<string> Roles { get; }
}