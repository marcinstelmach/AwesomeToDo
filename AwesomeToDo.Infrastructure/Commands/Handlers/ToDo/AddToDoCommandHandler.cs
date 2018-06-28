using System;
using System.Threading.Tasks;
using AwesomeToDo.Infrastructure.Commands.Abstract;
using AwesomeToDo.Infrastructure.Commands.Models.ToDo;
using AwesomeToDo.Infrastructure.Services.Abstract.Commands;

namespace AwesomeToDo.Infrastructure.Commands.Handlers.ToDo
{
    public class AddToDoCommandHandler : ICommandHandler<AddToDoCommandModel>
    {
        private readonly IToDoCommandService toDoCommandService;

        public AddToDoCommandHandler(IToDoCommandService toDoCommandService)
        {
            this.toDoCommandService = toDoCommandService;
        }

        public async Task HandleAsync(AddToDoCommandModel command)
            => await toDoCommandService.AddAsync(command.UserId, command.CardId, command.Title);
    }
}
