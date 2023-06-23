using Application.Credentials.CreateCredentials;
using Application.Credentials.Login;
using Application.Users.Commands.CreateUser;
using Application.Users.Commands.DeleteUser;
using Application.Users.Commands.RegisterUser;
using Application.Users.Commands.UpdateUser;
using Application.Users.Queries.GetUserByEmail;
using Application.Users.Queries.GetUserByFullName;
using Application.Users.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        [Authorize]
        [HttpPost("user")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request, CancellationToken cancellationToken)
        {
            var userCommand = new CreateUserCommand(request.email, request.firstName, request.lastName,
                request.dateOfBirth, request.degree);
            var userResult = await Sender.Send(userCommand,cancellationToken);
            if (userResult.IsFailure)
                return BadRequest(userResult.Error);

            var credentialsCommand = new CreateCredentialsCommand(userResult.Value.Id, request.password);
            var credentialsResult = await Sender.Send(credentialsCommand,cancellationToken);
            
            if (userResult.IsSuccess && credentialsResult.IsSuccess)
                return Ok(userResult.Value);
            else
                return BadRequest(credentialsResult.Error);
        }

        [Authorize]
        [HttpGet("user/{id}")]
        [ProducesResponseType(typeof(GetUserByIdResponse),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var query = new GetUserByIdQuery(id);
            var response = await Sender.Send(query, cancellationToken);

            return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
        }

        [Authorize]
        [HttpGet("user")]
        [ProducesResponseType(typeof(GetUserByFullNameResponse),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserByFullName([FromQuery] string fullName, CancellationToken cancellationToken)
        {
            var query = new GetUserByFullNameQuery(fullName);
            var response = await Sender.Send(query,cancellationToken);

            return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
        }

        [Authorize]
        [HttpGet("user/details/{id}")]
        [ProducesResponseType(typeof(GetUserByIdWithAllResponse),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetWholeUserInformation([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var query = new GetUserByIdWithAllQuery(id);
            var response = await Sender.Send(query, cancellationToken);

            return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
        }

        [Authorize]
        [HttpDelete("user/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUserById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteUserByIdCommand(id);
            var response = await Sender.Send(command, cancellationToken);

            return response.IsSuccess ? Ok() : NotFound(response.Error);
        }

        [Authorize]
        [HttpPut("user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command,cancellationToken);
            return result.IsSuccess ? Ok() : NotFound(result.Error);
        }
                
        [HttpPost("user/login")]
        [ProducesResponseType(typeof(string),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LoginUser([FromBody] LoginRequest request, CancellationToken cancellationToken)
        {
            var command = new LoginCommand(request.email,request.password);
            var result = await Sender.Send(command, cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : BadRequest();
        }

        [HttpGet("user/email")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CheckIfUserExistByEmail([FromQuery] string email,CancellationToken cancellationToken)
        {
            var query = new GetUserByEmailQuery(email);
            var result = await Sender.Send(query, cancellationToken);

            if (result.IsSuccess) return Ok(result.Value);
            else return BadRequest(result.Error);
        }
    }
}
