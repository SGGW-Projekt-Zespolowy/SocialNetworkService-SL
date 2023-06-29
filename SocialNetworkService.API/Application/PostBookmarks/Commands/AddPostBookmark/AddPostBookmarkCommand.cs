using Application.Abstractions.Messaging;

namespace Application.PostBookmarks.Commands.AddPostBookmark
{
    public record AddPostBookmarkCommand(Guid postId, Guid userId): ICommand;
    
}
