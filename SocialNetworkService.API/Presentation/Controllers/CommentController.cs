using Application.Comments.Commands.CreateComment;
using Application.Comments.Commands.DeleteComment;
using Application.Comments.Commands.UpdateComment;
using Application.Comments.Queries.GetCommentById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/comments")]
    public class CommentController : ApiController
    {
        public CommentController(ISender sender) : base(sender) { }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddComment([FromBody] CreateCommentCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);

            return result.IsSuccess ? Created(string.Empty, result) : BadRequest(result.Error);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetCommentByIdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCommentById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var query = new GetCommentByIdQuery(id);
            var response = await Sender.Send(query, cancellationToken);

            return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
        }

        [HttpGet("details/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetWholeCommentInformation([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var query = new GetCommentByIdWithAllQuery(id);
            var response = await Sender.Send(query, cancellationToken);

            return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCommentById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteCommentByIdCommand(id);
            var response = await Sender.Send(command, cancellationToken);

            return response.IsSuccess ? Ok() : NotFound(response.Error);
        }

        [HttpPut("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCommentById([FromBody] UpdateCommentCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);
            return result.IsSuccess ? Ok() : NotFound(result.Error);
        }
    }
}
