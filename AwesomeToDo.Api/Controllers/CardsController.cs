using System;
using System.Threading.Tasks;
using AwesomeToDo.Infrastructure.Commands.Abstract;
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
        public async Task<IActionResult> Get(Guid userId)
            => Ok(await userQueryService.Get(userId));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid userId, Guid cardId)
            => Ok(await userQueryService.Get(userId, cardId));
    }
}