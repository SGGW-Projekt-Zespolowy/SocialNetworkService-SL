using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Badge : Entity
    {
        public Badge(Guid id, Guid authorId, BadgeValue name) : base(id)
        {
            AuthorId = authorId;
            Name = name;
        }

        public Guid AuthorId { get; set; }
        public BadgeValue Name { get; set; }
    }
}
