using System.Threading.Tasks;
using AwesomeToDo.Domain.Entities;

namespace AwesomeToDo.Domain.Repositories.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        Task AddUserAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
    }
}
