using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User?> GetByFullNameAsync(string fullName, CancellationToken cancellationToken);
        Task<User?> GetByIdWithAllAsync(Guid id, CancellationToken cancellationToken);
        Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        void Add(User user, CancellationToken cancellationToken);
        void Remove(User user, CancellationToken cancellationToken);
        void Update(User user, CancellationToken cancellationToken);
    }
}
