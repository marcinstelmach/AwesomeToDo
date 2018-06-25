using System;
using System.Threading.Tasks;

namespace AwesomeToDo.Infrastructure.Services.Abstract.Commands
{
    public interface IToDoCommandService
    {
        Task AddAsync(Guid userId, Guid cardId, string title, string content);
        Task UpdateAsync(Guid userId, Guid cardId, Guid toDoId, string title, string content);
        Task DeleteAsync(Guid userId, Guid cardId, Guid toDoId);
    }
}
