using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Post : Entity
    {
        public Post(Guid id, Guid authorId, string content, MedicalSpecialization type, string title, DateTime modificationDate) : base(id)
        {
            AuthorId = authorId;
            CreationDate = DateTime.Now;
            Content = content;
            Type = type;
            Title = title;
            ModificationDate = modificationDate;
        }

        public Guid AuthorId { get; set; }
        public DateTime CreationDate { get; init; }
        public string Content { get; set; }
        public MedicalSpecialization Type { get; set; }
        public string Title { get; set; }
        public DateTime ModificationDate { get; set; }
        public List<Hashtag> Hashtags { get; } = new List<Hashtag>();
        public List<Reaction> Reactions { get; } = new List<Reaction>();
        public List<Comment> Comments { get; } = new List<Comment>();
    }
}
