using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeToDo.Domain.Data.Abstract;
using AwesomeToDo.Domain.Entities;
using AwesomeToDo.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace AwesomeToDo.Domain.Repositories.Concrete
{
    public class CardRepository : Repository<Card>, ICardRepository
    {
        private readonly IDbContext dbContext;

        public CardRepository(IDbContext dbContext)
            : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IList<Card>> GetUserCardsAsync(Guid userid)
            => await dbContext.Cards.Where(s => s.User.Id == userid).ToListAsync();
    }
}
