using System.Threading;
using System.Threading.Tasks;
using AwesomeToDo.Infrastructure.Dto.User;
using AwesomeToDo.Infrastructure.Requests.Models.Users;
using AwesomeToDo.Infrastructure.Services.Abstract.Queries;
using MediatR;

namespace AwesomeToDo.Infrastructure.Requests.Handlers.Users
{
    public class GetUserByIdRequestHandler : IRequestHandler<GetUserByIdRequestModel, UserDto>
    {
        private readonly IUserQueryService userQueryService;

        public GetUserByIdRequestHandler(IUserQueryService userQueryService)
        {
            this.userQueryService = userQueryService;
        }

        public async Task<UserDto> Handle(GetUserByIdRequestModel request, CancellationToken cancellationToken)
            => await userQueryService.Get(request.UserId);
    }
}
