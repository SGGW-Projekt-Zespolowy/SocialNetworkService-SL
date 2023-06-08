using Domain.Entities;

namespace Infrastructure.Specifications
{
    public class UserByIdIncludeAllSpecification: Specification<Domain.Entities.User>        
    {
        public UserByIdIncludeAllSpecification(Guid id):
            base (x => x.Id == id)
        {
            AddInclude(user => user.Specializations);
            AddInclude(user => user.Contacts);
            AddInclude(user => user.Followers);
            AddInclude(user => user.Publications);
            AddInclude(user => user.Posts);
            AddInclude(user => user.Badges);
            AddInclude(user => user.FollowedByMeUsers);
        }
    }
}
