using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<Comment?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Comment?> GetByIdWithAllAsync(Guid id, CancellationToken cancellationToken);
        void Add(Comment comment, CancellationToken cancellationToken);
        void Remove(Comment comment, CancellationToken cancellationToken);
        void Update(Comment comment, CancellationToken cancellationToken);
    }
}
