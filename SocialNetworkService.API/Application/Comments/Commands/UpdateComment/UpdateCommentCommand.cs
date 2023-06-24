using Application.Abstractions.Messaging;

namespace Application.Comments.Commands.UpdateComment
{
    public record class UpdateCommentCommand(Guid commentId, string content,bool? usefull) : ICommand;
}
