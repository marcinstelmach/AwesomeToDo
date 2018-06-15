using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AwesomeToDo.Infrastructure.Dto.User;

namespace AwesomeToDo.Infrastructure.Services.Abstract.Queries
{
    public interface IUserQueryService
    {
        Task<IList<UserDto>> Get();
        Task<UserDto> Get(Guid id);
    }
}
