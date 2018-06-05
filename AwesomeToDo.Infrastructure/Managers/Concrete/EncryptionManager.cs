using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using AwesomeToDo.Core.Exceptions;
using AwesomeToDo.Infrastructure.Managers.Abstract;
using Castle.Core.Internal;

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

        public string GetHash(string password, string salt)
        {
            throw new NotImplementedException();
        }
    }
}
