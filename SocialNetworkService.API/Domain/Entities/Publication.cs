using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Publication : Entity
    {
        public Publication(Guid id, Guid authorId, string title, string content, string link, string picture, MedicalSpecialization type, DateTime modificationDate)
            : base(id)
        {
            AuthorId = authorId;
            Title = title;
            Content = content;
            Link = link;
            Picture = picture;
            Type = type;
            ModificationDate = modificationDate;
            CreationDate = DateTime.Now;
        }

        public Guid AuthorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }
        public string Picture { get; set; }
        public MedicalSpecialization Type { get; set; }
        public DateTime CreationDate { get; init; }
        public DateTime ModificationDate { get; set; }
        public List<CoAuthor> CoAuthors { get; } = new List<CoAuthor>();
        public List<Hashtag> Hashtags { get; } = new List<Hashtag>();
        public List<Reaction> Reactions { get; } = new List<Reaction>();
        public List<Comment> Comments { get; } = new List<Comment>();
    }
}
