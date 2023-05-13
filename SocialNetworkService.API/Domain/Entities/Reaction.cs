using Domain.Primitives;

namespace Domain.Entities
{
    public class Reaction : Entity
    {
        public Reaction(Guid id, ReactionTypeEnum reactionType, Guid relatedItemId, Guid authorId) : base(id)
        {
            ReactionType = reactionType;
            RelatedItemId = relatedItemId;
            AuthorId = authorId;
        }

        public ReactionTypeEnum ReactionType { get; set; }
        public Guid RelatedItemId { get; set; }
        public Guid AuthorId { get; set; }
    }
}
