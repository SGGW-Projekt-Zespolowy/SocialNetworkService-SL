using Application.Abstractions.Messaging;

namespace Application.PostBookmarks.Commands.DeletePostBookmark
{
    public record DeletePostBookmarkCommand(Guid postBookmarkId): ICommand;
}
