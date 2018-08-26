using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AwesomeToDo.Infrastructure.Dto.User;
using AwesomeToDo.Infrastructure.Requests.Models.Users;
using AwesomeToDo.Infrastructure.Services.Abstract.Queries;
using MediatR;

namespace AwesomeToDo.Infrastructure.Requests.Handlers.Users
{
    public class GetUsersRequestHandler : IRequestHandler<GetUsersRequestModel, IList<UserDto>>
    {
        private readonly IUserQueryService userQueryService;

        public GetUsersRequestHandler(IUserQueryService userQueryService)
        {
            this.userQueryService = userQueryService;
        }

        public async Task<IList<UserDto>> Handle(GetUsersRequestModel request, CancellationToken cancellationToken)
            => await userQueryService.Get();
    }
}
