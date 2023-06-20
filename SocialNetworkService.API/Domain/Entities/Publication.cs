using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public sealed class Publication : AggregateRoot
    {
        public Publication(Guid id, Guid authorId, Title title, string content, Link link, string picture, MedicalSpecialization type)
            :base(id)
        {
            AuthorId = authorId;
            Title = title;
            Content = content;
            Link = link;
            Picture = picture;
            Type = type;
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
        }
        private Publication() { }
        public Guid AuthorId { get; set; }
        public User Author { get; set; }
        public Title Title { get; set; }
        public string Content { get; set; }
        public Link Link { get; set; }
        public string Picture { get; set; }        
        public MedicalSpecialization Type { get; set; }
        public DateTime CreationDate { get; init; }
        public DateTime ModificationDate { get; set; }
        public List<CoAuthor> CoAuthors { get; } = new List<CoAuthor>();
        public List<Comment> Comments { get; } = new List<Comment>();

        public void Update(Title? title, Content? content, Link? link, string picture, MedicalSpecialization? type)
        {
            if (title is not null) Title = title;
            if (content is not null) Content = content;
            if (link is not null) Link = link;
            if (picture != string.Empty) Picture = picture;
            if (type is not null) Type = type;
            ModificationDate = DateTime.Now;
        }
    }
}
