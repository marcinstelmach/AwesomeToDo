using System;
using System.Threading.Tasks;
using AwesomeToDo.Infrastructure.Requests.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeToDo.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
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
            await mediator.Send(request);
            return Accepted();
        }
    }
}