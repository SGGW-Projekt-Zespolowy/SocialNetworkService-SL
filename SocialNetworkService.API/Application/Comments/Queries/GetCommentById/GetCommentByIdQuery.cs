using Application.Abstractions.Messaging;

namespace Application.Comments.Queries.GetCommentById
{
    public sealed record GetCommentByIdQuery(Guid commentId) : IQuery<GetCommentByIdResponse>;
}
