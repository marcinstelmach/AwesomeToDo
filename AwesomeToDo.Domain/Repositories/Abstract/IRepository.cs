using System;
using System.Linq;
using System.Threading.Tasks;
using AwesomeToDo.Domain.Data.Abstract;

namespace AwesomeToDo.Domain.Repositories.Abstract
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> Get(Guid id);
        Task<IQueryable<T>> Get();
        Task Post(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<int> SaveChangesAsync();
    }
}
