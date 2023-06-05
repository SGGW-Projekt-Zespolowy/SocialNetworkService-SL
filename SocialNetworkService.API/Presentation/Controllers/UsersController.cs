using Application.Users.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/users")]
    public sealed class UsersController: ApiController
    {
        public UsersController(ISender sender): base(sender)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] CreateUserCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command,cancellationToken);

            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }
    }
}
