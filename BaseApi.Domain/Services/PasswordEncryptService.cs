using BaseApi.Domain.Interfaces.Services;
using System.Security.Cryptography;

namespace BaseApi.Domain.Services
{
    public class PasswordEncryptService : IPasswordEncryptService
    {
        private const int SaltSize = 128 / 8;
        private const int KeySize = 256 / 8;
        private const int Itenrations = 10000;
        private static readonly HashAlgorithmName _hashAlgorithmName = HashAlgorithmName.SHA256;
        private const char Delimiter = ';';

        public string Encrypt(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(SaltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Itenrations, _hashAlgorithmName, KeySize);

            return string.Join(Delimiter, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
        }

        public bool PasswordVerify(string passwordEncrypted, string password)
        {
            var elements = passwordEncrypted.Split(Delimiter);
            var salt = Convert.FromBase64String(elements[0]);
            var hash = Convert.FromBase64String(elements[1]);
            var hashInput = Rfc2898DeriveBytes.Pbkdf2(password, salt, Itenrations, _hashAlgorithmName, KeySize);

            return CryptographicOperations.FixedTimeEquals(hash, hashInput);
        }
    }
}
