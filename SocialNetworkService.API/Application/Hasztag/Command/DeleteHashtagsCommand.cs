using Application.Abstractions.Messaging;

namespace Application.Hasztag.Command
{
    public record DeleteHashtagsCommand(List<Guid> hashtagIds, Guid postId): ICommand;
}

