using AwesomeToDo.Domain.Data.Abstract;
using AwesomeToDo.Domain.Entities;
using AwesomeToDo.Domain.Repositories.Abstract;

namespace AwesomeToDo.Domain.Repositories.Concrete
{
    internal class ToDoRepository : Repository<ToDo>, IToDoRepository
    {
        private readonly IDbContext dbContext;
        public ToDoRepository(IDbContext dbContext) 
            : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
