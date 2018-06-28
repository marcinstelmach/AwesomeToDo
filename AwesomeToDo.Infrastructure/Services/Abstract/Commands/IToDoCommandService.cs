using System;
using System.Threading.Tasks;

namespace AwesomeToDo.Infrastructure.Services.Abstract.Commands
{
    public interface IToDoCommandService
    {
        Task AddAsync(Guid userId, Guid cardId, string title);
        Task UpdateAsync(Guid userId, Guid cardId, Guid toDoId, string title);
        Task DeleteAsync(Guid userId, Guid cardId, Guid toDoId);
    }
}
