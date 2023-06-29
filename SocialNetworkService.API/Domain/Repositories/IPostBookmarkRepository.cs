using Domain.Entities;

namespace Domain.Repositories
{
    public interface IPostBookmarkRepository
    {
        public Task<List<PostBookmark>> GetAll(Guid userId, CancellationToken cancellationToken);
        public void Add(PostBookmark postBookmark, CancellationToken cancellationToken);
        public Task Remove(PostBookmark postBookmark, CancellationToken cancellationToken);
        Task<PostBookmark?> GetByIdAsync(Guid postBookmarkId, CancellationToken cancellationToken);
        Task<List<PostBookmark>> GetAllByPostIdsAsync(List<Guid> postIds, CancellationToken cancellationToken);
    }
}
