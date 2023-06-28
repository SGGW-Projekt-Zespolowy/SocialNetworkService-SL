using Application.Abstractions.Messaging;

namespace Application.PostBookmarks.Queries.GetPostBookmarksByUserId
{
    public record GetPostBookmarksByUserIdQuery(Guid userId): IQuery<List<PostBookmarkResponse>>;
}
