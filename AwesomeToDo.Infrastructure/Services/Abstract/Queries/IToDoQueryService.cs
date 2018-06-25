using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AwesomeToDo.Infrastructure.Dto.ToDo;

namespace AwesomeToDo.Infrastructure.Services.Abstract.Queries
{
    public interface IToDoQueryService
    {
        Task<IList<ToDoDto>> Get(Guid userId, Guid cardId);
        Task<ToDoDto> Get(Guid userId, Guid cardId, Guid toDoId);
    }
}
