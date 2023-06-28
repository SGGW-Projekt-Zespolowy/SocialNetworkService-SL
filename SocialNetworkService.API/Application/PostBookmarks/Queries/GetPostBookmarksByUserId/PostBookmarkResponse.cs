namespace Application.PostBookmarks.Queries.GetPostBookmarksByUserId
{
    public class PostBookmarkResponse
    {
        public PostBookmarkResponse(Guid id, Guid postId, Guid userId)
        {
            Id = id;
            PostId = postId;
            UserId = userId;
        }

        public Guid Id { get; private set; }
        public Guid PostId { get; private set; }
        public Guid UserId { get; private set; }
    }
}
