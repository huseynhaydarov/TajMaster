using System.Security.Cryptography;
using TajMaster.Application.Common.Interfaces.PasswordHasher;

namespace TajMaster.Infrastructure.PasswordHasher;

public sealed class PasswordHasher : IPasswordHasher
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iterations = 10000;
    
    private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA256;
    public string HashPassword(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithm, HashSize);
        return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";
    }

    public bool VerifyHash(string password, string hashedPassword)
    {
        if (string.IsNullOrEmpty(hashedPassword) || !hashedPassword.Contains('-'))
        {
            throw new ArgumentException("Invalid hashed password format.", nameof(hashedPassword));
        }

        string[] parts = hashedPassword.Split('-');
        if (parts.Length != 2)
        {
            throw new ArgumentException("Invalid hashed password format.", nameof(hashedPassword));
        }

        try
        {
            byte[] hash = Convert.FromHexString(parts[0]);
            byte[] salt = Convert.FromHexString(parts[1]);

            byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithm, HashSize);

            // Use FixedTimeEquals for timing-attack resistance
            return CryptographicOperations.FixedTimeEquals(inputHash, hash);
        }
        catch (FormatException)
        {
            throw new ArgumentException("Invalid hashed password format.", nameof(hashedPassword));
        }
    }

}