using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class CoAuthor : Entity
    {
        public CoAuthor(Guid id, Guid authorId, Guid publicationId) : base(id)
        {
            AuthorId = authorId;
            PublicationId = publicationId;
        }

        public Guid AuthorId { get; set; }
        public Guid PublicationId { get; set; }
    }
}
