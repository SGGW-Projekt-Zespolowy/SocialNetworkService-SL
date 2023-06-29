using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Comment : AggregateRoot
    {
        public Comment(Guid id, Guid authorId, string content, Guid parentPostId, Guid parentCommentId, bool relatedToComment) : base(id)
        {
            AuthorId = authorId;
            Content = content;
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
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
        public bool RelatedToComment { get; set; }
        public bool Usefull { get; private set; }

        public void Update(Content? content, bool? usefull)
        {
            if (content is not null) Content = content;
            if (usefull is not null) Usefull = usefull.Value;
            ModificationDate = DateTime.Now;
        }

        public void CheckCommentUsefull() => Usefull = !Usefull;
    }
}
