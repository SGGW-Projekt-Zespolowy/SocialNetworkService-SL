using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
