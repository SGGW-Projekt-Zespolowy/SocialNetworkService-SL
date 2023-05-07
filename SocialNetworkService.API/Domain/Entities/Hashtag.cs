using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Hashtag : Entity
    {
        public Hashtag(Guid id, string name, Guid relatedItemId) : base(id)
        {
            Name = name;
            RelatedItemId = relatedItemId;
        }

        public string Name { get; set; }
        public Guid RelatedItemId { get; set; }
    }
}
