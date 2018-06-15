using System.Threading.Tasks;

namespace AwesomeToDo.Infrastructure.Commands.Abstract
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<T>(T command) where T : ICommandModel;
    }
}
