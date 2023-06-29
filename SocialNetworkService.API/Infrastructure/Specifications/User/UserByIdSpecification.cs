using Domain.Entities;

namespace Infrastructure.Specifications
{
    public class UserByIdSpecification: Specification<Domain.Entities.User>
    {
        public UserByIdSpecification(Guid id)
            :base(user => user.Id == id)
        {
            AddInclude(x => x.Specializations);
        }
    }
}
