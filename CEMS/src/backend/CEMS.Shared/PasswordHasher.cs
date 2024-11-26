using CEMS.Core.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace CEMS.Shared
{
    public class PasswordHasher : IPasswordHasher    
    {
        private const int SaltSize = 16; // 128-bit salt
        private const int HashSize = 32; // 256-bit hash
        private const int Iterations = 10000; // Recommended iteration count

        public string HashPassword(string password)
        {
            // Generate a salt
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Hash the password with the salt
            byte[] hash = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: Iterations,
                numBytesRequested: HashSize);

            // Combine salt and hash
            byte[] hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            // Return the result as a Base64 string
            return Convert.ToBase64String(hashBytes);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            // Decode the stored Base64 string
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);

            // Extract the salt from the hash
            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            // Hash the input password with the extracted salt
            byte[] hash = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: Iterations,
                numBytesRequested: HashSize);

            // Compare the resulting hash with the stored hash
            for (int i = 0; i < HashSize; i++)
            {
                if (hashBytes[SaltSize + i] != hash[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
