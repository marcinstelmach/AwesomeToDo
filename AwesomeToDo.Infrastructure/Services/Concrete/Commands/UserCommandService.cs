using System.Threading.Tasks;
using AwesomeToDo.Domain.Entities;
using AwesomeToDo.Domain.Repositories.Abstract;
using AwesomeToDo.Infrastructure.Services.Abstract.Commands;

namespace AwesomeToDo.Infrastructure.Services.Concrete.Commands
{
    internal class UserCommandService : IUserCommandService
    {
        private readonly IUserRepository userRepository;

        public UserCommandService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }


        public async Task AddUserAsync(string firstName, string lastName, string email,  string password)
        {
            var user = new User(firstName, lastName, email, password, "");
            await userRepository.Add(user);
            await userRepository.SaveChangesAsync();
        }
    }
}
