using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using TajMaster.Domain.Enumerations;

namespace TajMaster.Infrastructure.AuthService;

public class RoleAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options) : IAuthorizationPolicyProvider
{
    private readonly DefaultAuthorizationPolicyProvider _defaultProvider = new(options);

    public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        var role = UserRoleEnum.List().FirstOrDefault(r => 
            string.Equals(r.Name, policyName, StringComparison.OrdinalIgnoreCase));
        
        if (role != null)
        {
            var policy = new AuthorizationPolicyBuilder()
                .RequireRole(role.Name)
                .Build();
            return Task.FromResult<AuthorizationPolicy?>(policy);
        }
        
        return _defaultProvider.GetPolicyAsync(policyName);
    }
    
    public Task<AuthorizationPolicy> GetDefaultPolicyAsync() =>
        _defaultProvider.GetDefaultPolicyAsync();

    public Task<AuthorizationPolicy?> GetFallbackPolicyAsync() =>
        _defaultProvider.GetFallbackPolicyAsync();
}