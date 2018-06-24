using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeToDo.Infrastructure.Services.Abstract.Commands
{
    public interface ICardCommandService
    {
        Task AddAsync(Guid userId, string title);
        Task UpdateAsync(Guid cardId, Guid userId, string title);
    }
}
