using Application.Posts.Commands.CreatePost;
using Application.Posts.Commands.DeletePost;
using Application.Posts.Commands.UpdatePost;
using Application.Posts.Queries.GetPostById;
using Application.Publications.Commands.CreatePublication;
using Application.Publications.Commands.DeletePublication;
using Application.Publications.Commands.UpdatePublication;
using Application.Publications.Queries.GetPublicationById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/publications")]
    public sealed class PublicationsController : ApiController
    {
        public PublicationsController(ISender sender) : base(sender) { }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetPublicationByIdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPublicationById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var query = new GetPublicationByIdQuery(id);
            var response = await Sender.Send(query, cancellationToken);

            return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
        }

        [HttpGet("details/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetWholePublicationInformation([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var query = new GetPublicationByIdWithAllQuery(id);
            var response = await Sender.Send(query, cancellationToken);

            return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddPublication([FromBody] CreatePublicationCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);

            return result.IsSuccess ? Created(string.Empty, result) : BadRequest(result.Error);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePublicationById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new DeletePublicationByIdCommand(id);
            var response = await Sender.Send(command, cancellationToken);

            return response.IsSuccess ? Ok() : NotFound(response.Error);
        }

        [HttpPut("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePublicationById([FromBody] UpdatePublicationCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);
            return result.IsSuccess ? Ok() : NotFound(result.Error);
        }
    }
}
