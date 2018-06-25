using System;
using System.Threading.Tasks;
using AwesomeToDo.Domain.Extensions;
using AwesomeToDo.Infrastructure.Commands.Abstract;
using AwesomeToDo.Infrastructure.Commands.Models.ToDo;
using AwesomeToDo.Infrastructure.Services.Abstract.Queries;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeToDo.Api.Controllers
{
    [Route("api/users/{userId}/cards/{cardId}/todos")]
    [ApiController]
    public class ToDosController : ApiController
    {
        private readonly IToDoQueryService toDoQueryService;

        public ToDosController(ICommandDispatcher commandDispatcher, IToDoQueryService toDoQueryService) 
            : base(commandDispatcher)
        {
            this.toDoQueryService = toDoQueryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] Guid cardId)
            => Ok(await toDoQueryService.Get(User.Identity.GetUserIdIfExist(), cardId));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid cardId, [FromRoute] Guid id)
            => Ok(await toDoQueryService.Get(User.Identity.GetUserIdIfExist(), cardId, id));

        [HttpPost]
        public async Task<IActionResult> Post([FromRoute] Guid cardId, [FromBody] AddToDoCommandModel command)
            => await DispatchAsync(command.SetCardId(cardId).SetUserId(User.Identity.GetUserIdIfExist()));

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid cardId, [FromRoute] Guid id, [FromBody] UpdateToDoCommandModel command)
            => await DispatchAsync(command.SetCardId(cardId).SetUserId(User.Identity.GetUserIdIfExist()).SetId(id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid cardId, [FromRoute] Guid id)
            => await DispatchAsync(new DeleteToDoCommandModel(id, cardId, User.Identity.GetUserIdIfExist()));
    }
}