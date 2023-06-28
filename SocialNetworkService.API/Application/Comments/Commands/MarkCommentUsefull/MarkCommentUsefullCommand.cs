using Application.Abstractions.Messaging;

namespace Application.Comments.Commands.MarkCommentUsefull
{
    public record MarkCommentUsefullCommand(Guid commentId, bool isUsefull): ICommand;
}
