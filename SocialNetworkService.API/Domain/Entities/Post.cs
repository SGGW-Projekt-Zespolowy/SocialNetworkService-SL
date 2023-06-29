using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public sealed class Post : AggregateRoot
    {
        public Post(Guid id, Guid authorId, string content, MedicalSpecialization type, Title title, bool caseResolved) : base(id)
        {
            AuthorId = authorId;
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
            Content = content;
            Type = type;
            Title = title;
            CaseResolved = caseResolved;
        }
        protected Post() { }

        public Guid AuthorId { get; set; } = Guid.Empty;
        public User Author { get; set; }
        public DateTime CreationDate { get; init; } = DateTime.Now;
        public string Content { get; set; } = string.Empty;
        public MedicalSpecialization Type { get; set; }
        public Title Title { get; set; }
        public DateTime ModificationDate { get; set; }
        public bool CaseResolved { get; set; }
        public List<Comment> Comments { get; } = new List<Comment>();
        public List<Image> Images { get; } = new List<Image>();

        public void Update(Content? content, MedicalSpecialization? type, Title? title, bool? caseResolved)
        {
            if (content is not null) Content = content;
            if (type is not null) Type = type;
            if (title is not null) Title = title;
            if (caseResolved is not null) CaseResolved = caseResolved.Value;
            ModificationDate = DateTime.Now;
        }
    }
}
