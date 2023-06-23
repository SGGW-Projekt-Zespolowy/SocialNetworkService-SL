using Domain.Entities;

namespace Domain.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<Post?> GetByIdWithAllAsync(Guid id);
        Task<bool> Exists(Guid id);
        void Add(Post post);
        void Remove(Post post);
        void Update(Post post);
    }
}
