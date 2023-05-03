using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
