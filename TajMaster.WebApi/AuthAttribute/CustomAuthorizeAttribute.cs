using Microsoft.AspNetCore.Authorization;
using TajMaster.Domain.Enumerations;

namespace TajMaster.WebApi.AuthAttribute;

public class CustomAuthorizeAttribute : AuthorizeAttribute
{
    public CustomAuthorizeAttribute(params UserRoleEnum[] roles)
    {
        Roles = string.Join(",", roles.Select(r => r.Name));
    }
}