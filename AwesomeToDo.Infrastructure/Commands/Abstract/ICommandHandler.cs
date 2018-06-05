using System.Threading.Tasks;

namespace AwesomeToDo.Infrastructure.Commands.Abstract
{
    public interface ICommandHandler<T> where T : ICommandModel
    {
        Task HandleAsync(T command);
    }
}
