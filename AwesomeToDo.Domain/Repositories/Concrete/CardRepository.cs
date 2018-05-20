using AwesomeToDo.Domain.Data.Abstract;
using AwesomeToDo.Domain.Entities;
using AwesomeToDo.Domain.Repositories.Abstract;

namespace AwesomeToDo.Domain.Repositories.Concrete
{
    public class CardRepository : Repository<Card>, ICardRepository
    {
        private readonly IDbContext dbContext;

        public CardRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
