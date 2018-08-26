using System;
using System.Threading.Tasks;
using AwesomeToDo.Domain.Extensions;
using AwesomeToDo.Infrastructure.Commands.Abstract;
using AwesomeToDo.Infrastructure.Commands.Models.Card;
using AwesomeToDo.Infrastructure.Requests.Models.Cards;
using AwesomeToDo.Infrastructure.Services.Abstract.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeToDo.Api.Controllers
{
    [Route("api/users/{userId}/cards")]
    [ApiController]
    public class CardsController : ApiController
    {
        private readonly ICardQueryService userQueryService;
        private readonly IMediator mediator;
        public CardsController(ICommandDispatcher commandDispatcher, ICardQueryService userQueryService, IMediator mediator) 
            : base(commandDispatcher)
        {
            this.userQueryService = userQueryService;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await mediator.Send(new GetCardsRequestModel(User.Identity.GetUserIdIfExist())));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await userQueryService.Get(User.Identity.GetUserIdIfExist(), id));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddCardRequestModel model)
            => Accepted(await mediator.Send(model.SetUserId(User.Identity.GetUserIdIfExist())));

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, UpdateCardCommandModel command)
            => await DispatchAsync(command.SetId(id).SetUserId(User.Identity.GetUserIdIfExist()));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
            => await DispatchAsync(new DeleteCardCommandModel(id, User.Identity.GetUserIdIfExist()));
    }
}