using Application.Users.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/users")]
    public sealed class UsersController: ApiController
    {
        public UsersController(ISender sender): base(sender)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(CreateUserCommand command)
        {
            var result = await Sender.Send(command);

            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }
    }
}
