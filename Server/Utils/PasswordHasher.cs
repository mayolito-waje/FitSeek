using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Server.Utils;

public static class PasswordHasher
{
    public static byte[] Hash(string password, byte[] salt)
    {
        byte[] passwordHash = KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8
        );

        return passwordHash;
    }
}
