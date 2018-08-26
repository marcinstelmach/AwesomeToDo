using System.Threading;
using System.Threading.Tasks;
using AwesomeToDo.Infrastructure.Requests.Models.Users;
using AwesomeToDo.Infrastructure.Services.Abstract.Commands;
using MediatR;

namespace AwesomeToDo.Infrastructure.Requests.Handlers.Users
{
    public class AddUserRequestHandler : IRequestHandler<AddUserRequestModel, Unit>
    {
        private readonly IUserCommandService userCommandService;

        public AddUserRequestHandler(IUserCommandService userCommandService)
        {
            this.userCommandService = userCommandService;
        }

        public async Task<Unit> Handle(AddUserRequestModel request, CancellationToken cancellationToken)
        {
            await userCommandService.AddUserAsync(request.FirstName, request.LastName, request.Email,
                request.Password);
            return Unit.Value;
        }
    }
}
