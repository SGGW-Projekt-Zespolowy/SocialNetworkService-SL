using Application.Abstractions.Messaging;
using Application.Posts.Queries.GetByScope;
using Application.Posts.Queries.GetPostById;
using Domain.Entities;

namespace Application.Posts.Queries.Get
{
    public sealed record GetPostsByScopeQuery(int Page, int PageSize) : IQuery<GetPostsByScopeQueryResponse>;
}
