using System.Threading.Tasks;
using AwesomeToDo.Infrastructure.Commands.Abstract;
using AwesomeToDo.Infrastructure.Commands.Models.User;
using AwesomeToDo.Infrastructure.Dto.Token;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace AwesomeToDo.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ApiController
    {
        private readonly IMemoryCache cache;
        public AuthController(ICommandDispatcher commandDispatcher, IMemoryCache cache)
            : base(commandDispatcher)
        {
            this.cache = cache;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginUserCommandModel command)
        {
            await DispatchAsync(command);
            return Ok(cache.Get<TokenDto>(command.TokenId));
        }
    }
}