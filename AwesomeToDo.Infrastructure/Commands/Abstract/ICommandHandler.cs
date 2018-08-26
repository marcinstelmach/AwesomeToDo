using System.Threading.Tasks;

namespace AwesomeToDo.Infrastructure.Commands.Abstract
{
    public interface ICommandHandler<in T> where T : ICommandModel
    {
        Task HandleAsync(T command);
    }
}
