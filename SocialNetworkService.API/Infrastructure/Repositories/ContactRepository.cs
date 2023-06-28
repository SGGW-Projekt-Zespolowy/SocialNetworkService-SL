using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Infrastructure.Repositories
{
    internal class ContactRepository : IContactRepository
    {
        private readonly DatabaseContext _dbContext;

        public ContactRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(List<Contact> contacts, CancellationToken cancellationToken)
        {
            _dbContext.Set<Contact>().AddRange(contacts);
        }

        public async Task<Contact> GetByIdsAsync(Guid userId, Guid contactId, CancellationToken cancellationToken)
            => await ApplySpecification(new ContactByIdsSpecification(userId, contactId)).FirstOrDefaultAsync(cancellationToken);
        public IQueryable<Contact> ApplySpecification(Specification<Contact> specification)
        {
            return SpecificationEvaluator.GetQuery(_dbContext.Set<Contact>(), specification);
        }
        public async Task<List<Contact>> GetAll(Guid userId, int page, int pageSize, CancellationToken cancellationToken)
        {
            IQueryable<Contact> contactsQuery = _dbContext.Set<Contact>();
            var contacts = await contactsQuery
                .Where(c => c.UserId == userId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Include(c => c.ContactUser)
                .ToListAsync(cancellationToken);

            return contacts;
        }

        public void Remove(List<Contact> contacts, CancellationToken cancellationToken)
        {
            _dbContext.Set<Contact>().RemoveRange(contacts);
        }

        public void Update(Contact contact, CancellationToken cancellationToken)
        {
            _dbContext.Set<Contact>().Update(contact);
        }
    }
}
