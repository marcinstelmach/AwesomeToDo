using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AwesomeToDo.Infrastructure.Commands.Abstract;
using AwesomeToDo.Infrastructure.Commands.Models.User;
using AwesomeToDo.Infrastructure.Services.Abstract.Commands;
using Microsoft.Extensions.Caching.Memory;

namespace AwesomeToDo.Infrastructure.Commands.Handlers.User
{
    public class LoginUserCommandHandler : ICommandHandler<LoginUserCommandModel>
    {
        private readonly IUserCommandService userCommandService;
        private readonly IMemoryCache cache;

        public LoginUserCommandHandler(IUserCommandService userCommandService, IMemoryCache cache)
        {
            this.userCommandService = userCommandService;
            this.cache = cache;
        }

        public async Task HandleAsync(LoginUserCommandModel command)
        {
            if (command.TokenId == Guid.Empty)
            {
                command.TokenId = Guid.NewGuid();
            }

            var token = await userCommandService.LoginUserAsync(command.Email, command.Password);
            cache.Set(command.TokenId, token, TimeSpan.FromSeconds(7));
        }
    }
}
