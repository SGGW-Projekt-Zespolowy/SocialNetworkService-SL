using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Reaction : Entity
    {
        public Reaction(Guid id, ReactionType reactionType, Guid relatedItemId, Guid authorId) : base(id)
        {
            ReactionType = reactionType;
            RelatedItemId = relatedItemId;
            AuthorId = authorId;
        }

        public ReactionType ReactionType { get; set; }
        public Guid RelatedItemId { get; set; }
        public Guid AuthorId { get; set; }

        public void Update(ReactionType? reactionType)
        {
            if(reactionType is not null) ReactionType = reactionType;
        }
    }
}
