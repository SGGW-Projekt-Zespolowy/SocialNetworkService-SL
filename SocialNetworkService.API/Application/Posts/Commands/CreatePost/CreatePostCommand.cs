using Application.Abstractions.Messaging;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace Application.Posts.Commands.CreatePost
{
    public sealed record CreatePostCommand(
        Guid authorId, string content, string type, string title /*, List<string> hashtags, List<IFormFile> images */
        ) : ICommand;
}
