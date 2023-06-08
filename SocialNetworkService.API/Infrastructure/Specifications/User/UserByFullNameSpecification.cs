using Domain.Entities;

namespace Infrastructure.Specifications.User
{
    public class UserByFullNameSpecification: Specification<Domain.Entities.User>
    {
        public UserByFullNameSpecification(string fullName):
            base(user => (user.FirstName+" "+user.LastName) == fullName)
        {}
    }
}
