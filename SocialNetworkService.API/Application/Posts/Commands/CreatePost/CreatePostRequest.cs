using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Posts.Commands.CreatePost
{
    public record CreatePostRequest( Guid authorId, string content, string type, string title/*,  List<string> hashtags, List<IFormFile> images */);
}
