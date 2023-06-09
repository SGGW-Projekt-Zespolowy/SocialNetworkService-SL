using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<Comment?> GetByIdWithAllAsync(Guid id);
        void Add(Comment comment);
        void Remove(Comment comment);
        void Update(Comment comment);
    }
}
