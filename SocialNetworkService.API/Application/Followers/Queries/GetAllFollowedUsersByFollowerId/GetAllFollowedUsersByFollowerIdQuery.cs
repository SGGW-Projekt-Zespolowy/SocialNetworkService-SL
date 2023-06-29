using Application.Abstractions.Messaging;
using Application.Followers.Queries.GetAllFollowedUsersByFollowerId;

namespace Application.Followers.Queries.GetAllFollowedUsersByFollowerId
{
    public sealed record GetAllFollowedUsersByFollowerIdQuery(Guid followerId, int page, int pageSize) : IQuery<GetAllFollowedUsersByFollowerIdResponse>;
}
