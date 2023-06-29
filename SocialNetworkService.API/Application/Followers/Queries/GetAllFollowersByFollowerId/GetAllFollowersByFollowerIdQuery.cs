using Application.Abstractions.Messaging;

namespace Application.Followers.Queries.GetAllFollowersByUserId
{
    public sealed record GetAllFollowersByFollowerIdQuery(Guid followerId, int page, int pageSize) : IQuery<GetAllFollowersByFollowerIdResponse>;
}
