using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class PostBookmark: Entity
    {
        public PostBookmark(Guid id, Guid postId, Guid userId): base(id)
        {
            PostId = postId;
            UserId = userId;
        }

        public Guid PostId { get; private set; }
        public Guid UserId { get; private set; }
    }
}
