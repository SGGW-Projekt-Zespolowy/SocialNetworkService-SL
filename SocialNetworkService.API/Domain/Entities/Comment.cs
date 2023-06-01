using Domain.Primitives;

namespace Domain.Entities
{
    public class Comment : AggregateRoot
    {
        public Comment(Guid id, Guid authorId, string content, DateTime modificationDate, Guid parentPostId, Guid parentCommentId, bool relatedToComment) : base(id)
        {
            AuthorId = authorId;
            Content = content;
            CreationDate = DateTime.Now;
            ModificationDate = modificationDate;
            ParentPostId = parentPostId;
            ParentCommentId = parentCommentId;
            RelatedToComment = relatedToComment;
        }

        public Guid AuthorId { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; init; }
        public DateTime ModificationDate { get; set; }
        public Guid ParentPostId { get; set; }
        public Guid ParentCommentId { get; set; }
        public List<Comment> Comments { get; set; }
        public bool RelatedToComment { get; set; }
        public List<Reaction> Reactions { get; } = new List<Reaction>();
        public List<Comment> Comments { get; } = new List<Comment>();
    }
}
