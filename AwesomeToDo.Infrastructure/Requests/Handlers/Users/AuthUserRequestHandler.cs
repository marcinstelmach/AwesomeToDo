using System.Threading;
using System.Threading.Tasks;
using AwesomeToDo.Infrastructure.Dto.Token;
using AwesomeToDo.Infrastructure.Requests.Models.Users;
using AwesomeToDo.Infrastructure.Services.Abstract.Commands;
using MediatR;

namespace AwesomeToDo.Infrastructure.Requests.Handlers.Users
{
    public class AuthUserRequestHandler : IRequestHandler<AuthUserRequestModel, TokenDto>
    {
        private readonly IUserCommandService userCommandService;

        public AuthUserRequestHandler(IUserCommandService userCommandService)
        {
            this.userCommandService = userCommandService;
        }

        public async Task<TokenDto> Handle(AuthUserRequestModel request, CancellationToken cancellationToken)
            => await userCommandService.LoginUserAsync(request.Email, request.Password);
    }
}
