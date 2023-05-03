using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class CoAuthor : Entity
    {
        public CoAuthor(Guid id, Guid authorId, Guid publicationId) : base(id)
        {
            AuthorId = authorId;
            PublicationId = publicationId;
        }

        public Guid AuthorId { get; set; }
        public Guid PublicationId { get; set; }
    }
}
