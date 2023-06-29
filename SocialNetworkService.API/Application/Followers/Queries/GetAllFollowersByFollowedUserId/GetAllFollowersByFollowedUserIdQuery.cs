using Application.Abstractions.Messaging;
using Application.Followers.Queries.GetAllFollowersByFollowedUserId;

namespace Application.Followers.Queries.GetAllFollowersByFollowedUserId
{
    public sealed record GetAllFollowersByFollowedUserIdQuery(Guid followedUserId, int page, int pageSize) : IQuery<GetAllFollowersByFollowedUserIdResponse>;
}
