using System;
using AwesomeToDo.Infrastructure.Dto.User;
using MediatR;

namespace AwesomeToDo.Infrastructure.Requests.Models.Users
{
    public class GetUserByIdRequestModel : IRequest<UserDto>
    {
        public Guid UserId { get; }

        public GetUserByIdRequestModel(Guid userId)
        {
            UserId = userId;
        }
    }
}
