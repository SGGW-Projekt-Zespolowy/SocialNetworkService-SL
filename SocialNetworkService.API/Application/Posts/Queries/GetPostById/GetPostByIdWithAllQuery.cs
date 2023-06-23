using Application.Abstractions.Messaging;

namespace Application.Posts.Queries.GetPostById
{
    public record GetPostByIdWithAllQuery(Guid postId) : IQuery<GetPostByIdWithAllResponse>;
}
