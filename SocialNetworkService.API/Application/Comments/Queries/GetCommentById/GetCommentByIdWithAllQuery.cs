using Application.Abstractions.Messaging;

namespace Application.Comments.Queries.GetCommentById
{
    public record GetCommentByIdWithAllQuery(Guid commentId) : IQuery<GetCommentByIdWithAllResponse>;
}
