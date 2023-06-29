using Application.Contacts.Queries.GetAllContactsByUserId;
using Application.Followers.Commands.AddFollower;
using Application.Followers.Commands.DeleteFollower;
using Application.Followers.Queries.GetAllFollowedUsersByFollowerId;
using Application.Followers.Queries.GetAllFollowersByFollowedUserId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/followers")]
    public class FollowersController : ApiController
    {
        public FollowersController(ISender sender) : base(sender) { }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddFollower([FromBody] AddFollowerCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);

            return result.IsSuccess ? Created(string.Empty, result) : BadRequest(result.Error);
        }

        [HttpDelete("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteFollowerByIds([FromBody] DeleteFollowerByIdsCommand command, CancellationToken cancellationToken)
        {
            var response = await Sender.Send(command, cancellationToken);

            return response.IsSuccess ? Ok() : NotFound(response.Error);
        }       

        [HttpGet("followedUsers")]
        [ProducesResponseType(typeof(GetAllFollowedUsersByFollowerIdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllFollowedUsersByFollowerId([FromQuery] Guid followerId, [FromQuery] int page, [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            var query = new GetAllFollowedUsersByFollowerIdQuery(followerId, page, pageSize);
            var response = await Sender.Send(query, cancellationToken);

            return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
        }

        [HttpGet("followers")]
        [ProducesResponseType(typeof(GetAllFollowersByFollowedUserIdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllFollowersByFollowedUserId([FromQuery] Guid followedUserId, [FromQuery] int page, [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            var query = new GetAllFollowersByFollowedUserIdQuery(followedUserId, page, pageSize);
            var response = await Sender.Send(query, cancellationToken);

            return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
        }
    }
}
