using System;
using System.Linq;
using System.Threading.Tasks;
using AwesomeToDo.Domain.Data.Abstract;

namespace AwesomeToDo.Domain.Repositories.Abstract
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> GetAsync(Guid id);
        Task<IQueryable<T>> GetAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> SaveChangesAsync();
    }
}
