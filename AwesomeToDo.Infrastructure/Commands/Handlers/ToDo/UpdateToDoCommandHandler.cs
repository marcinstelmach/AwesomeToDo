using System.Threading.Tasks;
using AwesomeToDo.Infrastructure.Commands.Abstract;
using AwesomeToDo.Infrastructure.Commands.Models.ToDo;
using AwesomeToDo.Infrastructure.Services.Abstract.Commands;

namespace AwesomeToDo.Infrastructure.Commands.Handlers.ToDo
{
    public class UpdateToDoCommandHandler : ICommandHandler<UpdateToDoCommandModel>
    {
        private readonly IToDoCommandService toDoCommandService;

        public UpdateToDoCommandHandler(IToDoCommandService doCommandService)
        {
            toDoCommandService = doCommandService;
        }

        public async Task HandleAsync(UpdateToDoCommandModel command)
            => await toDoCommandService.UpdateAsync(command.UserId, command.CardId, command.Id, command.Title);
    }
}
