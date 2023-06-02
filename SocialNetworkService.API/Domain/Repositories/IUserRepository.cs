using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User?> GetByIdWithAllAsync(Guid id);
        void Add(User user);
        void Remove(User user);
        void Update(User user);
    }
}
