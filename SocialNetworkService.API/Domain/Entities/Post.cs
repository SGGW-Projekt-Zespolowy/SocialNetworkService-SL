using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public sealed class Post : AggregateRoot
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
        protected Post() { }

        public Guid AuthorId { get; set; } = Guid.Empty;
        public DateTime CreationDate { get; init; } = DateTime.Now;
        public string Content { get; set; } = string.Empty;
        public MedicalSpecialization Type { get; set; } = MedicalSpecialization.Create("Default").Value;
        public string Title { get; set; } = string.Empty;
        public DateTime ModificationDate { get; set; } = DateTime.Now;
        public List<Hashtag> Hashtags { get; } = new List<Hashtag>();
        public List<Reaction> Reactions { get; } = new List<Reaction>();
        public List<Comment> Comments { get; } = new List<Comment>();
    }
}
