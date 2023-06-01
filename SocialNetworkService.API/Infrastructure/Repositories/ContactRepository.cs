using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories
{
    internal class ContactRepository : IContactRepository
    {
        private readonly DatabaseContext _dbContext;

        public ContactRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Contact contact)
        {
            _dbContext.Set<Contact>().Add(contact);
        }

        public void Remove(Contact contact)
        {
            _dbContext.Set<Contact>().Remove(contact);
        }

        public void Update(Contact contact)
        {
            _dbContext.Set<Contact>().Update(contact);
        }
    }
}
