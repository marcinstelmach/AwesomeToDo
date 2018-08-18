using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AwesomeToDo.Tests
{
    public static class TestExtensions
    {
        public static IEnumerable<MethodInfo> GetInvalidAsyncMethods(this Type[] types)
            => types.SelectMany(c => c.GetMethods())
                .Where(m => m.ReturnType.IsAssignableFrom(typeof(Task<>)) && !m.Name.EndsWith("Async"));
    }
}
