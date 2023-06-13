using Application.Abstractions.Messaging;

namespace Application.Posts.Commands.DeletePost
{
    public sealed record DeletePostByIdCommand(Guid postId) : ICommand;
}
