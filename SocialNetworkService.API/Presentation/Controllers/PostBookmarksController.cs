using Application.PostBookmarks.Commands.AddPostBookmark;
using Application.PostBookmarks.Commands.DeletePostBookmark;
using Application.PostBookmarks.Queries.GetPostBookmarksByUserId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/post-bookmarks")]
    public sealed class PostBookmarksController: ApiController
    {
        public PostBookmarksController(ISender sender): base(sender)
        {                
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] AddPostBookmarkCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command,cancellationToken);

            return result.IsSuccess ? Ok() : BadRequest(result.Error);
        }

        [HttpDelete("{postBookmarkId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Remove([FromRoute] Guid postBookmarkId, CancellationToken cancellationToken)
        {
            var command = new DeletePostBookmarkCommand(postBookmarkId);
            var result = await Sender.Send(command, cancellationToken);

            return result.IsSuccess ? Ok() : BadRequest(result?.Error);
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(typeof(List<PostBookmarkResponse>),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByUserId([FromRoute] Guid userId, CancellationToken cancellationToken)
        {
            var query = new GetPostBookmarksByUserIdQuery(userId);
            var result = await Sender.Send(query, cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : BadRequest(result?.Error);
        }
    }
}
