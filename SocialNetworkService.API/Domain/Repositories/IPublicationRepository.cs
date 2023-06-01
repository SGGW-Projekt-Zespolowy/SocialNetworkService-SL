using Domain.Entities;

namespace Domain.Repositories
{
    public interface IPublicationRepository : IRepository<Publication>
    {
        Task<Publication?> GetByIdWithAllAsync(Guid id);
        void Add(Publication publication);
        void Remove(Publication publication);
        void Update(Publication publication);
    }
}
