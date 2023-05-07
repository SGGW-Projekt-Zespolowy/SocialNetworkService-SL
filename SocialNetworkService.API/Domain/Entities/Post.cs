using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Post : Entity
    {
        public Post(Guid id, Guid authorId, DateTime creationDate, string content, MedicalSpecialization type, string title, DateTime modificationDate) : base(id)
        {
            AuthorId = authorId;
            CreationDate = creationDate;
            Content = content;
            Type = type;
            Title = title;
            ModificationDate = modificationDate;
        }

        public Guid AuthorId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Content { get; set; }
        public MedicalSpecialization Type { get; set; }
        public string Title { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
