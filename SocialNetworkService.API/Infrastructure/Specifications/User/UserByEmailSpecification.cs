using Domain.ValueObjects;

namespace Infrastructure.Specifications.User
{
    public class UserByEmailSpecification: Specification<Domain.Entities.User>
    {
        public UserByEmailSpecification(Email email)
            :base(x => x.Email == email.Value)
        {
        }
    }
}
