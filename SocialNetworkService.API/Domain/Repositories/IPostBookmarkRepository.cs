using Domain.Entities;

namespace Domain.Repositories
{
    public interface IPostBookmarkRepository
    {
        public Task<List<PostBookmark>> GetAll(Guid userId, CancellationToken cancellationToken);
        public void Add(PostBookmark postBookmark, CancellationToken cancellationToken);
        public Task Remove(PostBookmark postBookmark, CancellationToken cancellationToken);
        Task<PostBookmark?> GetById(Guid postBookmarkId, CancellationToken cancellationToken);
    }
}
