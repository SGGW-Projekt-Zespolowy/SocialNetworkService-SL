using Application.Contacts.Commands.AddContact;
using Application.Contacts.Commands.DeleteContact;
using Application.Contacts.Queries.GetAllContactsByUserId;
using Application.Posts.Commands.DeletePost;
using Application.Posts.Queries.Get;
using Application.Posts.Queries.GetByScope;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/contacts")]
    public class ContactsController : ApiController
    {
        public ContactsController(ISender sender) : base(sender) { }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddContact([FromBody] AddContactCommand command, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(command, cancellationToken);

            return result.IsSuccess ? Created(string.Empty, result) : BadRequest(result.Error);
        }

        [HttpDelete("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteContactByIds([FromBody] DeleteContactByIdsCommand command, CancellationToken cancellationToken)
        {
            var response = await Sender.Send(command, cancellationToken);

            return response.IsSuccess ? Ok() : NotFound(response.Error);
        }

        [HttpGet()]
        [ProducesResponseType(typeof(GetAllContactsByUserIdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllByScope([FromQuery] Guid userId, [FromQuery] int page, [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            var query = new GetAllContactsByUserIdQuery(userId, page, pageSize);
            var response = await Sender.Send(query, cancellationToken);

            return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
        }
    }
}
