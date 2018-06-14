using System.Threading.Tasks;
using AwesomeToDo.Infrastructure.Dto.Token;

namespace AwesomeToDo.Infrastructure.Services.Abstract.Commands
{
    public interface IUserCommandService
    {
        Task AddUserAsync(string firstName, string lastName, string email, string password);
        Task<TokenDto> LoginUserAsync(string email, string password);
    }
}
