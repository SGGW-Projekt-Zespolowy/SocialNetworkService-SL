using Application.Abstractions.Messaging;

namespace Application.Comments.Commands.DeleteComment
{
    public sealed record DeleteCommentByIdCommand(Guid commentId) : ICommand;
}
