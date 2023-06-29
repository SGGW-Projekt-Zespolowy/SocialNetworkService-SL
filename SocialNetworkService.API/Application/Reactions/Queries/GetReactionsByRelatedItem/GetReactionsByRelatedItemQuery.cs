using Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reactions.Queries.GetReactionsByRelatedItem
{
    public sealed record GetReactionsByRelatedItemQuery(Guid relatedItemId) : IQuery<GetReactionsByRelatedItemResponse>;
}
