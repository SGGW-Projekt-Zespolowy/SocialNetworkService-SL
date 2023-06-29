using Application.Posts.Commands.CreatePost;
using Application.Posts.Commands.DeletePost;
using Application.Posts.Commands.UpdatePost;
using Application.Posts.Queries.Get;
using Application.Posts.Queries.GetByScope;
using Application.Posts.Queries.GetPostById;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/posts")]
    public sealed class PostsController : ApiController
    {
        public PostsController(ISender sender) : base(sender) { }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddPost([FromForm] CreatePostRequest request, CancellationToken cancellationToken)
        {
            var command = new CreatePostCommand(request.authorId, request.content, request.type, request.title/*,
                request.hashtags, request.images */);
            var result = await Sender.Send(command, cancellationToken);

            return result.IsSuccess ? Created(string.Empty, result) : BadRequest(result.Error);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetPostByIdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPostById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var query = new GetPostByIdQuery(id);
            var response = await Sender.Send(query, cancellationToken);

            return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(GetPostsByScopeQueryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllByScope([FromQuery] int page, [FromQuery] int pageSize,[FromQuery] Guid userId, CancellationToken cancellationToken)
        {
            var query = new GetPostsByScopeQuery(page, pageSize, userId);
            var response = await Sender.Send(query, cancellationToken);

            return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
        }

        [HttpGet("details/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GetPostByIdWithAllResponse),StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetWholePostInformation([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var query = new GetPostByIdWithAllQuery(id);
            var response = await Sender.Send(query, cancellationToken);

            return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePostById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new DeletePostByIdCommand(id);
            var response = await Sender.Send(command, cancellationToken);

            return response.IsSuccess ? Ok() : NotFound(response.Error);
        }

        [HttpPut("{postId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePostById([FromRoute] Guid postId, [FromBody] UpdatePostRequest request, CancellationToken cancellationToken)
        {
            var command = new UpdatePostCommand(postId, request.content, request.type, request.title, request.caseResolved);
            var result = await Sender.Send(command, cancellationToken);
            return result.IsSuccess ? Ok() : NotFound(result.Error);
        }
    }
}
