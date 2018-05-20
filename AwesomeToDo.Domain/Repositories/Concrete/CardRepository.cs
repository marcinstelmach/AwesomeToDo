using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeToDo.Core.Exceptions;
using AwesomeToDo.Domain.Data.Abstract;
using AwesomeToDo.Domain.Entities;
using AwesomeToDo.Domain.Extensions;
using AwesomeToDo.Domain.Repositories.Abstract;

namespace AwesomeToDo.Domain.Repositories.Concrete
{
    public class CardRepository : ICardRepository
    {
        private readonly IDbContext dbContext;

        public CardRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Card> Get(Guid id)
            => await dbContext.Cards.FindAndEnsureExistAsync(id, ErrorCode.UserNotExist);

        public async Task<IQueryable<Card>> Get()
            => await Task.Run(() => dbContext.Cards);

        public async Task Post(Card entity)
            => await dbContext.Cards.AddAsync(entity);

        public async Task Update(Card entity)
            => await Task.Run(() => dbContext.Cards.Update(entity));

        public async Task Delete(Card entity)
            => await Task.Run(() => dbContext.Cards.Remove(entity));
    }
}
