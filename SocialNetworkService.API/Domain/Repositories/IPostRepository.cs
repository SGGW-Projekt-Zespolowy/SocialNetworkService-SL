using Domain.Entities;

namespace Domain.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<Post?> GetByIdWithAllAsync(Guid id, CancellationToken cancellationToken);
        Task<Post?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        void Add(Post post, CancellationToken cancellationToken);
        void Remove(Post post, CancellationToken cancellationToken);
        void Update(Post post, CancellationToken cancellationToken);
        Task<Post?> GetByIdWithAllAsync(Guid id);
        Task<bool> Exists(Guid id);
        void Add(Post post);
    }
}
