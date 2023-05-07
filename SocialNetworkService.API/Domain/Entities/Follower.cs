using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Follower : Entity
    {
        public Follower(Guid id, Guid followerId, Guid followedUserId) : base(id)
        {
            FollowerId = followerId;
            FollowedUserId = followedUserId;
        }

        public Guid FollowerId { get; set; }
        public Guid FollowedUserId { get; set; }
    }
}
