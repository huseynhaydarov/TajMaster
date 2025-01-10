using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using TajMaster.Domain.Enumerations;

namespace TajMaster.Infrastructure.AuthService;

public class RoleAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options) : IAuthorizationPolicyProvider
{
    private readonly DefaultAuthorizationPolicyProvider _defaultProvider = new(options);

    public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        if (!Enum.TryParse<Role>(policyName, out var role)) return _defaultProvider.GetPolicyAsync(policyName);
        var policy = new AuthorizationPolicyBuilder();
        policy.RequireRole(role.ToString());
        return Task.FromResult<AuthorizationPolicy?>(policy.Build());

    }

    public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => 
        _defaultProvider.GetDefaultPolicyAsync();

    public Task<AuthorizationPolicy?> GetFallbackPolicyAsync() => 
        _defaultProvider.GetFallbackPolicyAsync();
}