using Domain.Entities;

namespace Application.Comments.Queries.GetCommentById
{
    public record GetCommentByIdWithAllResponse(
        Guid id, Guid authorId, string content, 
        DateTime creationDate, DateTime modificationDate,
        Guid parentPostId, Guid parentCommentId, bool relatedToComment,
        List<Comment> comments, List<Reaction> reactions);
}
