using Application.Posts.Commands.CreatePost;
using Application.Posts.Commands.UpdatePost;
using Application.Reactions.Commands.AddReaction;
using Application.Reactions.Commands.DeleteReaction;
using Application.Reactions.Commands.UpdateReaction;
using Application.Reactions.Queries.GetReactionsByRelatedItem;
using Application.Users.Commands.DeleteUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/reactions")]
    public sealed class ReactionsController : ApiController
    {
        public ReactionsController(ISender sender) : base(sender) { }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddReaction([FromBody] AddReactionCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);

            return result.IsSuccess ? Created(string.Empty, result) : BadRequest(result.Error);
        }

        [HttpPut("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpateReaction([FromBody] UpdateReactionCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);
            return result.IsSuccess ? Ok() : NotFound(result.Error);
        }

        [HttpGet("{postId}")]
        [ProducesResponseType(typeof(GetReactionsByRelatedItemResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPostReactions([FromRoute] Guid postId, CancellationToken cancellationToken)
        {
            var query = new GetReactionsByRelatedItemQuery(postId);
            var response = await Sender.Send(query, cancellationToken);

            return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteReactionById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteReactionByIdCommand(id);
            var response = await Sender.Send(command, cancellationToken);

            return response.IsSuccess ? Ok() : NotFound(response.Error);
        }
    }
}
