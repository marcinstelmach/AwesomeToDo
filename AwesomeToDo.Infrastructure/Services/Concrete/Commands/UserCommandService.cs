using System.Threading.Tasks;
using AwesomeToDo.Domain.Data.Abstract;
using AwesomeToDo.Domain.Entities;
using AwesomeToDo.Domain.Repositories.Abstract;
using AwesomeToDo.Infrastructure.Dto.Token;
using AwesomeToDo.Infrastructure.Managers.Abstract;
using AwesomeToDo.Infrastructure.Services.Abstract.Commands;
using Microsoft.Extensions.Caching.Memory;

namespace AwesomeToDo.Infrastructure.Services.Concrete.Commands
{
    internal class UserCommandService : IUserCommandService
    {
        private readonly IUserRepository userRepository;
        private readonly IEncryptionManager encryptionManager;
        private readonly ITokenManager tokenManager;

        public UserCommandService(IUserRepository userRepository, IEncryptionManager encryptionManager, ITokenManager tokenManager)
        {
            this.userRepository = userRepository;
            this.encryptionManager = encryptionManager;
            this.tokenManager = tokenManager;
        }


        public async Task AddUserAsync(string firstName, string lastName, string email,  string password)
        {
            var salt = encryptionManager.GetSalt(password);
            var hash = encryptionManager.GetHash(password, salt);
            var user = new User(firstName, lastName, email, hash, salt);
            await userRepository.AddUserAsync(user);
            await userRepository.SaveChangesAsync();
        }

        public async Task<TokenDto> LoginUserAsync(string email, string password)
        {
            var user = await userRepository.GetUserByEmailAsync(email);
            var hash = encryptionManager.GetHash(password, user.Salt);
            encryptionManager.CompareHash(user.Password, hash);
            return tokenManager.GenerateToken(user.Id, user.Email);
        }
    }
}
