using Domain.Entities;

namespace Infrastructure.Specifications
{
    public class PostByIdIncludeAllSpecification : Specification<Domain.Entities.Post>
    {
        public PostByIdIncludeAllSpecification(Guid id) :
            base(x => x.Id == id)
        {
            AddInclude(post => post.Comments);
        }
    }
}