using System.Threading.Tasks;
using AwesomeToDo.Infrastructure.Commands.Abstract;
using AwesomeToDo.Infrastructure.Commands.Models.User;
using AwesomeToDo.Infrastructure.Services.Abstract.Commands;

namespace AwesomeToDo.Infrastructure.Commands.Handlers.User
{
    public class AddUserCommandHandler : ICommandHandler<AddUserCommandModel>
    {
        private readonly IUserCommandService userCommandService;

        public AddUserCommandHandler(IUserCommandService userCommandService)
        {
            this.userCommandService = userCommandService;
        }

        public async Task HandleAsync(AddUserCommandModel command)
            => await userCommandService.AddUserAsync(command.FirstName, command.LastName, command.Email, command.Password);
    }
}
