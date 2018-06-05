using System;
using System.Threading.Tasks;
using AwesomeToDo.Infrastructure.Commands.Abstract;
using AwesomeToDo.Infrastructure.Commands.Models.User;
using AwesomeToDo.Infrastructure.Services.Abstract.Queries;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeToDo.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ApiController
    {
        private readonly IUserQueryService userQueryService;
        public UserController(ICommandDispatcher commandDispatcher, IUserQueryService userQueryService) 
            : base(commandDispatcher)
        {
            this.userQueryService = userQueryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await userQueryService.Get());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await userQueryService.Get(id));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUserCommandModel command)
            => await DispatchAsync(command);
    }
}