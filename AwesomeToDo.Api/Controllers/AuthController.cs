using System.Threading.Tasks;
using AwesomeToDo.Infrastructure.Requests.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeToDo.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthUserRequestModel model)
            => Ok(await mediator.Send(model));
    }
}