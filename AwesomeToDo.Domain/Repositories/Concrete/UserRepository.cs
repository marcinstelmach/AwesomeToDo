using System.Threading.Tasks;
using AwesomeToDo.Core.Exceptions;
using AwesomeToDo.Domain.Data.Abstract;
using AwesomeToDo.Domain.Entities;
using AwesomeToDo.Domain.Extensions;
using AwesomeToDo.Domain.Repositories.Abstract;

namespace AwesomeToDo.Domain.Repositories.Concrete
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IDbContext dbContext;

        public UserRepository(IDbContext dbContext)
            : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddUserAsync(User user)
        {
            await dbContext.Users.EnsureUserNotExistAsync(user.Email);
            await AddAsync(user);
        }

        public async Task<User> GetUserByEmailAsync(string email)
            => await dbContext.Users.FindAndEnsureSingleAsync(s => s.Email == email, ErrorCode.UserWithGivenEmailNotExist);
    }
}
