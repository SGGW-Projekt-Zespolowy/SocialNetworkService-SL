using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Follower : Entity
    {
        public Follower(Guid id, Guid followerId, Guid followerUserId) : base(id)
        {
            FollowerId = followerId;
            FollowerUserId = followerUserId;
        }

        public Guid FollowerId { get; set; }
        public Guid FollowerUserId { get; set; }
    }
}
