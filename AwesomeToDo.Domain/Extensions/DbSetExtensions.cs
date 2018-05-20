using System;
using System.Threading.Tasks;
using AwesomeToDo.Core.Exceptions;
using AwesomeToDo.Domain.Data.Abstract;
using Microsoft.EntityFrameworkCore;

namespace AwesomeToDo.Domain.Extensions
{
    public static class DbSetExtensions
    {
        public static async Task<T> FindAndEnsureExistAsync<T>(this DbSet<T> set, Guid id, ErrorCode errorCode) where T : Entity
        {
            var result = await set.FindAsync(id);
            if (result == null)
            {
                throw new AwesomeToDoException(errorCode);
            }

            return result;
        }
    }
}
