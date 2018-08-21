using System.Collections.Generic;
using AwesomeToDo.Infrastructure.Dto.User;
using MediatR;

namespace AwesomeToDo.Infrastructure.Requests.Models.Users
{
    public class GetUsersRequestModel : IRequest<IList<UserDto>>
    {
    }
}
