using Application.Abstractions.Messaging;
using Domain.ValueObjects;

namespace Application.Posts.Commands.CreatePost
{
    public sealed record CreatePostCommand(
        Guid authorId, string content, string type, string title
        ) : ICommand;
}
