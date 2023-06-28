using Domain.Entities;

namespace Infrastructure.Specifications
{
    public class ContactByIdsSpecification : Specification<Domain.Entities.Contact>
    {
        public ContactByIdsSpecification(Guid userId, Guid contactId)
            : base(contact => contact.UserId == userId && contact.ContactId == contactId ) { }
    }
}

