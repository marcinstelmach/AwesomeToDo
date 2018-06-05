using System;
using System.Threading.Tasks;
using AwesomeToDo.Infrastructure.Commands.Abstract;
using AwesomeToDo.Infrastructure.Commands.Models.User;

namespace AwesomeToDo.Infrastructure.Commands.Handlers.User
{
    public class AddUserCommandHandler : ICommandHandler<AddUserCommandModel>
    {
        public async Task HandleAsync(AddUserCommandModel command)
        {
            throw new NotImplementedException();
        }
    }
}
