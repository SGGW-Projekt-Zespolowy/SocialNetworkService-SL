using Domain.Entities;

namespace Domain.Repositories
{
    public interface IPublicationRepository : IRepository<Publication>
    {
        Task<Publication?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Publication?> GetByIdWithAllAsync(Guid id, CancellationToken cancellationToken);
        void Add(Publication publication, CancellationToken cancellationToken);
        void Remove(Publication publication, CancellationToken cancellationToken);
        void Update(Publication publication, CancellationToken cancellationToken);
    }
}
