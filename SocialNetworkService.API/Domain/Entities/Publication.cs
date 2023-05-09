using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public sealed class Publication : Entity
    {
        public Publication(Guid id, Guid authorId, Title title, string content, Link link, string picture, ValueObjects.Type type)
            :base(id)
        {
            AuthorId = authorId;
            Title = title;
            Content = content;
            Link = link;
            Picture = picture;
            Type = type;
        }

        public Guid AuthorId { get; set; }
        public Title Title { get; set; }
        public string Content { get; set; }
        public Link Link { get; set; }
        public string Picture { get; set; }
        public ValueObjects.Type Type { get; set; }
    }
}
