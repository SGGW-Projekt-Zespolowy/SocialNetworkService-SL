using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Publication : Entity
    {
        public Publication(Guid id, Guid authorId, string title, string content, string link, string picture, Specialization type)
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
        public string Title { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }
        public string Picture { get; set; }
        public MedicalSpecialization Type { get; set; }
    }
}
