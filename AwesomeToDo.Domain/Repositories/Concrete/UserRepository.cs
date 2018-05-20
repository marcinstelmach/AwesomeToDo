using System;
using System.Linq;
using System.Threading.Tasks;
using AwesomeToDo.Core.Exceptions;
using AwesomeToDo.Domain.Data.Abstract;
using AwesomeToDo.Domain.Entities;
using AwesomeToDo.Domain.Extensions;
using AwesomeToDo.Domain.Repositories.Abstract;

namespace AwesomeToDo.Domain.Repositories.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContext dbContext;

        public UserRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> Get(Guid id)
            => await dbContext.Users.FindAndEnsureExistAsync(id, ErrorCode.UserNotExist);

        public async Task<IQueryable<User>> Get()
            => await Task.Run(() => dbContext.Users);

        public async Task Post(User entity)
            => await dbContext.Users.AddAsync(entity);


        public async Task Update(User entity)
            => await Task.Run(() => dbContext.Users.Update(entity));

        public async Task Delete(User entity)
            => await Task.Run(() => dbContext.Users.Remove(entity));
    }
}
