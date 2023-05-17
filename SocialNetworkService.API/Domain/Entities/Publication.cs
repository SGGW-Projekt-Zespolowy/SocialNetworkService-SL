using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public sealed class Publication : Entity
    {
        public Publication(Guid id, Guid authorId, Title title, string content, Link link, string picture, ValueObjects.MedicalSpecialization type)
            :base(id)
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
        public Title Title { get; set; }
        public string Content { get; set; }
        public Link Link { get; set; }
        public string Picture { get; set; }
        public MedicalSpecialization Type { get; set; }
        public DateTime CreationDate { get; init; }
        public DateTime ModificationDate { get; set; }
        public List<CoAuthor> CoAuthors { get; } = new List<CoAuthor>();
        public List<Hashtag> Hashtags { get; } = new List<Hashtag>();
        public List<Reaction> Reactions { get; } = new List<Reaction>();
        public List<Comment> Comments { get; } = new List<Comment>();
        public ValueObjects.MedicalSpecialization Type { get; set; }
    }
}
