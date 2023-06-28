using Domain.Entities;

namespace Domain.Repositories
{
    public interface IContactRepository
    {
        void Add(List<Contact> contacts, CancellationToken cancellationToken);
        void Remove(List<Contact> contacts, CancellationToken cancellationToken);
        void Update(Contact contact, CancellationToken cancellationToken);
        Task<Contact> GetByIdsAsync(Guid userId, Guid contactId, CancellationToken cancellationToken);

        Task<List<Contact>> GetAll(Guid userId, int page, int pageSize, CancellationToken cancellationToken);
    }
}
