using System;
using System.Threading.Tasks;
using AwesomeToDo.Infrastructure.Commands.Abstract;
using AwesomeToDo.Infrastructure.Commands.Models.Card;
using AwesomeToDo.Infrastructure.Services.Abstract.Queries;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeToDo.Api.Controllers
{
    [Route("api/users/{userId}/cards")]
    [ApiController]
    public class CardsController : ApiController
    {
        private readonly ICardQueryService userQueryService;
        public CardsController(ICommandDispatcher commandDispatcher, ICardQueryService userQueryService) 
            : base(commandDispatcher)
        {
            this.userQueryService = userQueryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await userQueryService.Get(Guid.Parse(User.Identity.Name)));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await userQueryService.Get(Guid.Parse(User.Identity.Name), id));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddCardCommandModel command)
            => await DispatchAsync(command.SetUserId(Guid.Parse(User.Identity.Name)));
    }
}