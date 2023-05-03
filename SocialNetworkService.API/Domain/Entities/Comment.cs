using Domain.Primitives;

namespace Domain.Entities
{
    public class Comment : Entity
    {
        public Comment(Guid id, Guid authorId, string content, DateTime creationDate, DateTime modificationDate, Guid parentPostId, Guid parentCommentId, bool relatedToComment) : base(id)
        {
            AuthorId = authorId;
            Content = content;
            CreationDate = creationDate;
            ModificationDate = modificationDate;
            ParentPostId = parentPostId;
            ParentCommentId = parentCommentId;
            RelatedToComment = relatedToComment;
        }

        public Guid AuthorId { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public Guid ParentPostId { get; set; }
        public Guid ParentCommentId { get; set; }
        public bool RelatedToComment { get; set; }
    }
}
