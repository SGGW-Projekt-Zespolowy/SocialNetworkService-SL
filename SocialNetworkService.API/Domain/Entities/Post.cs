using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class Post : Entity
    {
        public Post(Guid id, Guid authorId, DateTime creationDate, string content, Type type, string title, DateTime modificationDate) : base(id)
        {
            AuthorId = authorId;
            CreationDate = creationDate;
            Content = content;
            Type = type;
            Title = title;
            ModificationDate = modificationDate;
        }

        public Guid AuthorId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Content { get; set; }
        public MedicalSpecialization Type { get; set; }
        public string Title { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
