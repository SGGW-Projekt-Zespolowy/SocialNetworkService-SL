using Domain.Entities;

namespace Infrastructure.Specifications
{
    public class PostByIdSpecification : Specification<Domain.Entities.Post>
    {
        public PostByIdSpecification(Guid id)
            : base(post => post.Id == id) { }
    }
}

