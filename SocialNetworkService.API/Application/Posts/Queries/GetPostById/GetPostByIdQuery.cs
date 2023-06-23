using Application.Abstractions.Messaging;
using Application.Users.Queries.GetUserById;

namespace Application.Posts.Queries.GetPostById
{
    public sealed record GetPostByIdQuery(Guid postId) : IQuery<GetPostByIdResponse>;
}
