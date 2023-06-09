using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class CoAuthor : Entity
    {
        public CoAuthor(Guid id, Guid userId, Guid publicationId) : base(id)
        {
            UserId = userId;
            PublicationId = publicationId;
        }

        public Guid UserId { get; set; }
        public User User { get; private set; }  
        public Guid PublicationId { get; set; }
        public Publication Publication { get; private set; }
    }
}
