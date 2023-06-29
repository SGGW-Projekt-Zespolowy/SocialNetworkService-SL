using Application.Abstractions.Messaging;
using Application.Posts.Queries.GetByScope;

namespace Application.Posts.Queries.Get
{
    public sealed record GetPostsByScopeQuery(int Page, int PageSize, Guid userId) : IQuery<GetPostsByScopeQueryResponse>;
}
