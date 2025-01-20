using Microsoft.AspNetCore.Authorization;
using TajMaster.Domain.Enumerations;

namespace TajMaster.WebApi.AuthAttribute;

public class CustomAuthorizeAttribute : AuthorizeAttribute
{
    public CustomAuthorizeAttribute(params Role[] roles)
    {
        Roles = string.Join(",", roles);
    }
}