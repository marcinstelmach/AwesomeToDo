using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AwesomeToDo.Domain.Entities;

namespace AwesomeToDo.Domain.Repositories.Abstract
{
    public interface ICardRepository : IRepository<Card>
    {
        Task<IList<Card>> GetUserCardsAsync(Guid userid);
    }
}
