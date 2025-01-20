using TajMaster.Domain.Abstractions;

namespace TajMaster.Domain.Enumerations;

public class UserRoleEnum : BaseEnum
{
    public static readonly UserRoleEnum Customer = 
        new(Guid.Parse("e36f8db3-6b4a-412a-90f4-41b98f9fa2c6"), "Customer", "user-customer", true);
    public static readonly UserRoleEnum Craftsman = 
        new(Guid.Parse("f46e4db3-7a4b-422b-91e4-51c99f9fa3d7"), "Craftsman", "user-craftsman", true);
    public static readonly UserRoleEnum Admin = 
        new(Guid.Parse("a56f5cb3-8b5b-432b-92f5-61d99f9fa4e8"), "Admin", "user-admin", true);
    public static readonly UserRoleEnum Guest = 
        new(Guid.Parse("b66f6db3-9b6c-442b-93f6-71e99f9fa5f9"), "Guest", "user-guest", true);

    public UserRoleEnum(Guid id, string name, string code, bool isActive)
        : base(name, code, isActive)
    {
        Id = id;
    }

    public new static IEnumerable<UserRoleEnum> List() => new[] { Customer, Craftsman, Admin, Guest };
}