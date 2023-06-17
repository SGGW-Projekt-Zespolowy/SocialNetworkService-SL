using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Specifications.Comment
{
    public class CommentByIdIncludeAllSpecification : Specification<Domain.Entities.Comment>
    {
        public CommentByIdIncludeAllSpecification(Guid id) : 
            base(x => x.Id == id)
        {
            AddInclude(comment => comment.Comments);
            AddInclude(comment => comment.Reactions);
        }
    }
}
