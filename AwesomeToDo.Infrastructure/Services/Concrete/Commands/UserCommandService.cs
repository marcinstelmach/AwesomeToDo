using System.Threading.Tasks;
using AwesomeToDo.Domain.Data.Abstract;
using AwesomeToDo.Domain.Entities;
using AwesomeToDo.Domain.Repositories.Abstract;
using AwesomeToDo.Infrastructure.Managers.Abstract;
using AwesomeToDo.Infrastructure.Services.Abstract.Commands;

namespace AwesomeToDo.Infrastructure.Services.Concrete.Commands
{
    internal class UserCommandService : IUserCommandService
    {
        private readonly IUserRepository userRepository;
        private readonly IEncryptionManager encryptionManager;
        private readonly IDbContext dbContext;

        public UserCommandService(IUserRepository userRepository, IEncryptionManager encryptionManager, IDbContext dbContext)
        {
            this.userRepository = userRepository;
            this.encryptionManager = encryptionManager;
            this.dbContext = dbContext;
        }


        public async Task AddUserAsync(string firstName, string lastName, string email,  string password)
        {
            var salt = encryptionManager.GetSalt(password);
            var hash = encryptionManager.GetHash(password, salt);
            var user = new User(firstName, lastName, email, hash, salt);
            await userRepository.AddUserAndEnsureNotExistWithGivenEmailAsync(user);
            await userRepository.SaveChangesAsync();
        }
    }
}
