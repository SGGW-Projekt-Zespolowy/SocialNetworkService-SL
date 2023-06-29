using Domain.Entities;

namespace Infrastructure.Specifications
{
    public class GetFollowerByIdSpecification : Specification<Domain.Entities.Follower>
    {
        public GetFollowerByIdSpecification(Guid followerId, Guid followedUserId)
            : base(follower => follower.FollowerId == followerId && follower.FollowedUserId == followedUserId) { }
    }
}

