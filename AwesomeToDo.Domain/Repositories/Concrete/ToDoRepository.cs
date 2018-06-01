using AwesomeToDo.Domain.Entities;
using AwesomeToDo.Domain.Repositories.Abstract;

namespace AwesomeToDo.Domain.Repositories.Concrete
{
    public class ToDoRepository : Repository<ToDo>, IToDoRepository
    {
    }
}
