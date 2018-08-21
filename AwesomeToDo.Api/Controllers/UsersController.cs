using System;
using System.Linq;
using System.Threading.Tasks;
using AwesomeToDo.Core.Exceptions;
using AwesomeToDo.Infrastructure.Commands.Abstract;
using AwesomeToDo.Infrastructure.Requests.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeToDo.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ApiController
    {
        private readonly IMediator mediator;
        private readonly ICommandDispatcher commandDispatcher;

        public UsersController(IMediator mediator, ICommandDispatcher commandDispatcher)
            : base(commandDispatcher)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await mediator.Send(new GetUsersRequestModel()));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await mediator.Send(new GetUserByIdRequestModel(id)));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUserRequestModel request)
        {
            ValidateModel();
            await mediator.Send(request);
            return Accepted();
        }
    }
}