using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class Publication : Entity
    {
        public Publication(Guid id, Guid authorId, string title, string context, string link, byte[] picture, MedicalSpecialization type) : base(id)
        {
            AuthorId = authorId;
            Title = title;
            Context = context;
            Link = link;
            Picture = picture;
            Type = type;
        }

        public Guid AuthorId { get; set; }
        public string Title { get; set; }
        public string Context { get; set; }
        public string Link { get; set; }
        public byte[] Picture { get; set; }
        public MedicalSpecialization Type { get; set; }
    }
}
