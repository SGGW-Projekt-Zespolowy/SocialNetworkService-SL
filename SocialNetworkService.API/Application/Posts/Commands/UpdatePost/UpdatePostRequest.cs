using Microsoft.AspNetCore.Http;

namespace Application.Posts.Commands.UpdatePost
{
    public record class UpdatePostRequest(
        Guid postId, string content, string type, string title, bool? caseResolved);
}
