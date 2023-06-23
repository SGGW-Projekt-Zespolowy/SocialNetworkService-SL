namespace Application.Comments.Queries.GetCommentById
{
    public record GetCommentByIdResponse(
        Guid id, Guid authorId, string content,
        DateTime creationDate, DateTime modificationDate,
        Guid parentPostId, Guid parentCommentId, bool relatedToComment);
}
