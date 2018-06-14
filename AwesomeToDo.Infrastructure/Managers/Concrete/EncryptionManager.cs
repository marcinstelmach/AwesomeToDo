using System;
using System.Security.Cryptography;
using AwesomeToDo.Core.Exceptions;
using AwesomeToDo.Infrastructure.Managers.Abstract;

namespace AwesomeToDo.Infrastructure.Managers.Concrete
{
    public class EncryptionManager : IEncryptionManager
    {
        private const int DeriveBytesIterationsCount = 10000;
        private const int SaltSize = 40;
        public string GetSalt(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new AwesomeToDoException(ErrorCode.EmptyPasswordForSaltGenerate);
            }

            var saltBytes = new byte[SaltSize];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }

        public string GetHash(string value, string salt)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new AwesomeToDoException(ErrorCode.EmptyPasswordForSaltGenerate);
            }
            if (string.IsNullOrWhiteSpace(salt))
            {
                throw new AwesomeToDoException(ErrorCode.EmptySaltForGenerateHash);
            }

            var pbkdf2 = new Rfc2898DeriveBytes(value, GetBytes(salt), DeriveBytesIterationsCount);

            return Convert.ToBase64String(pbkdf2.GetBytes(SaltSize));
        }

        private byte[] GetBytes(string value)
        {
            var bytes = new byte[value.Length * sizeof(char)];

            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);
            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);

            return bytes;
        }
    }
}
