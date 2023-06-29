using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICredentialsRepository
    {
        void Add(Credentials credentials);
        void Remove(Credentials credentials);
        void Update(Credentials credentials);
        Task<Credentials?> GetByUserIdAsync(Guid userId);
    }
}
