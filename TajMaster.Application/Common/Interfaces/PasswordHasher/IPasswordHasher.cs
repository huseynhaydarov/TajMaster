namespace TajMaster.Application.Common.Interfaces.PasswordHasher;

public interface IPasswordHasher
{
    string HashPassword(string password);
    bool VerifyHash(string password, string hash);
}