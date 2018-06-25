using System;
using System.Collections.Generic;
using System.Linq;
using AwesomeToDo.Core.Exceptions;

namespace AwesomeToDo.Domain.Extensions
{
    public static class ReadOnlyCollectionExtensions
    {
        public static T FindIfExist<T>(this IReadOnlyCollection<T> collection, Func<T, bool> func, ErrorCode errorCode)
        {
            var result = collection.SingleOrDefault(func);
            if (result == null)
            {
                throw new AwesomeToDoException(errorCode);
            }

            return result;
        }
    }
}
