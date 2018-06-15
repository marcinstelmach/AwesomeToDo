using System.Linq;
using System.Threading.Tasks;
using AwesomeToDo.Core.Exceptions;
using AwesomeToDo.Infrastructure.Commands.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeToDo.Api.Controllers
{
    public class ApiController : ControllerBase
    {
        private readonly ICommandDispatcher commandDispatcher;

        public ApiController(ICommandDispatcher commandDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
        }

        protected async Task<IActionResult> DispatchAsync<T>(T command) where T : ICommandModel
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(", ", ModelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage));
                throw new AwesomeToDoException(ErrorCode.InvalidCommand, errors);
            }

            await commandDispatcher.DispatchAsync(command);
            return Accepted();
        }
    }
}