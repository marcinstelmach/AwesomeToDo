using System.Threading.Tasks;
using AwesomeToDo.Infrastructure.Commands.Abstract;
using AwesomeToDo.Infrastructure.Commands.Models.ToDo;
using AwesomeToDo.Infrastructure.Services.Abstract.Commands;

namespace AwesomeToDo.Infrastructure.Commands.Handlers.ToDo
{
    public class DeleteToDoCommandHandler : ICommandHandler<DeleteToDoCommandModel>
    {
        private readonly IToDoCommandService toDoCommandService;

        public DeleteToDoCommandHandler(IToDoCommandService doCommandService)
        {
            toDoCommandService = doCommandService;
        }

        public async Task HandleAsync(DeleteToDoCommandModel command)
            => await toDoCommandService.DeleteAsync(command.UserId, command.CardId, command.Id);
    }
}
