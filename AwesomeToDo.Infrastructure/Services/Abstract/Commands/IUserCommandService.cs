using System.Threading.Tasks;

namespace AwesomeToDo.Infrastructure.Services.Abstract.Commands
{
    public interface IUserCommandService
    {
        Task AddUserAsync(string firstName, string lastName, string email, string password);
    }
}
