using System.Security.Cryptography;

namespace BuffMeUp.Backend.Core;

public static class PasswordHasher
{
    const int SaltSize = 16;
    const int KeySize = 32;
    const int Iterations = 10000;
    static HashAlgorithmName HashAlgorithmName = HashAlgorithmName.SHA512;
    const char Separator = ';';

    public static string HashPassword(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName, KeySize);

        return string.Join(Separator, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
    }

    public static bool VerifyPassword(string passwordHash, string password)
    {
        var elements = passwordHash.Split(Separator);
        var salt = Convert.FromBase64String(elements[0]);
        var hash = Convert.FromBase64String(elements[1]);

        var newHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName, KeySize);

        return CryptographicOperations.FixedTimeEquals(hash, newHash);
    }
}
