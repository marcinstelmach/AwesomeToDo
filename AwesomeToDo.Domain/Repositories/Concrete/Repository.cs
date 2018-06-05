using System;
using System.Linq;
using System.Threading.Tasks;
using AwesomeToDo.Core.Exceptions;
using AwesomeToDo.Domain.Data.Abstract;
using AwesomeToDo.Domain.Extensions;
using AwesomeToDo.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace AwesomeToDo.Domain.Repositories.Concrete
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly IDbContext dbContext;
        private readonly DbSet<T> dbSet;

        protected Repository()
        {

        }

        public Repository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public async Task<T> Get(Guid id)
            => await dbSet.FindAndEnsureExistAsync(id, ErrorCode.GenericNotExist<T>());

        public async Task<IQueryable<T>> Get()
            => await Task.Run(() => dbSet);

        public async Task Add(T entity)
            => await dbSet.AddAsync(entity);

        public async Task Update(T entity)
            => await Task.Run(() => dbSet.Update(entity));

        public async Task Delete(T entity)
            => await Task.Run(() => dbSet.Remove(entity));

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new AwesomeToDoException(ErrorCode.FaultWhileSavingToDatabase, e.Message, e);
            }
        }
    }
}
