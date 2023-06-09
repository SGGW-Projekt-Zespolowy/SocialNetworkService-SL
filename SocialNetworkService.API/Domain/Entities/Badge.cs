using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Badge : Entity
    {
        public Badge(Guid id, Guid authorId, BadgeEnum name) : base(id)
        {
            AuthorId = authorId;
            Name = name;
        }

        public Guid AuthorId { get; set; }
        public User User { get; private set; }
        public BadgeEnum Name { get; set; }
    }
}
