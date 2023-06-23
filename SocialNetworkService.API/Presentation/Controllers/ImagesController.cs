using Application.Images.Commands.AddPicture;
using Application.Images.Commands.DeletePictures;
using Application.Images.Queries.GetImagesByPostId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/images")]
    public sealed class ImagesController: ApiController
    {
        public ImagesController(ISender sender): base(sender)
        {                
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddPictures([FromForm] AddPicturesCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);

            return result.IsSuccess ? Ok() : BadRequest(result.Error);
        }

        [HttpDelete("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemovePictures([FromBody] DeletePicturesCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);

            return result.IsSuccess? Ok() : BadRequest(result.Error);
        }

        [HttpGet("{postId}")]
        [ProducesResponseType(typeof(GetImagesByPostIdQueryResponse),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetImagesByPostId([FromRoute] Guid postId, CancellationToken cancellationToken)
        {
            var query = new GetImagesByPostIdQuery(postId);
            var result = await Sender.Send(query, cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
        }
    }
}
