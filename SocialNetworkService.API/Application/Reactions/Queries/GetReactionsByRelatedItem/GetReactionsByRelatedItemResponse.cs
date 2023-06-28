using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reactions.Queries.GetReactionsByRelatedItem
{
    public sealed class GetReactionsByRelatedItemResponse
    {
        public GetReactionsByRelatedItemResponse()
        {
            Reactions = new List<ReactionResponse>();
        }
        public List<ReactionResponse> Reactions { get; set; }
    }

    public class ReactionResponse
    {
        public ReactionResponse(Guid id, string reactionType, Guid authorId)
        {
            Id = id;
            ReactionType = reactionType;
            AuthorId = authorId;
        }
        public Guid Id { get; set; }
        public string ReactionType { get; set; }
        public Guid AuthorId { get; set; }
    }
}
