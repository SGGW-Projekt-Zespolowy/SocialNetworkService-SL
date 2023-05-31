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
        /// <summary>
        /// the person that is following
        /// </summary>
        public Guid FollowerId { get; set; }
        public User FollowerUser { get; set; }
        /// <summary>
        /// the person that is followed
        /// </summary>
        public Guid FollowedUserId { get; set; }
        public User FollowedUser { get; set; }
    }
}
