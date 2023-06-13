using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public sealed class Post : AggregateRoot
    {
        public Post(Guid id, Guid authorId, string content, MedicalSpecialization type, Title title) : base(id)
        {
            AuthorId = authorId;
            CreationDate = DateTime.Now;
            Content = content;
            Type = type;
            Title = title;
        }
        protected Post() { }

        public Guid AuthorId { get; set; } = Guid.Empty;
        public User Author { get; set; }
        public DateTime CreationDate { get; init; } = DateTime.Now;
        public string Content { get; set; } = string.Empty;
        public MedicalSpecialization Type { get; set; } = MedicalSpecialization.Create("Default").Value;
        public Title Title { get; set; } = Title.Create(string.Empty).Value;
        public DateTime ModificationDate { get; set; }
        public List<Comment> Comments { get; } = new List<Comment>();

        public void Update(Content? content, MedicalSpecialization? type, Title? title)
        {
            if (content is not null) Content = content;
            if (type is not null) Type = type;
            if (title is not null) Title = title;
            ModificationDate = DateTime.Now;
        }
    }
}
