using Domain.Entities;

namespace Domain.Repositories
{
    public interface IImageRepository
    {
        public void Add(Image image, CancellationToken cancellationToken);
        public Task Delete(Guid imageId, CancellationToken cancellationToken);
        public Task<List<Image>> GetAllByPostIdAsync(Guid postId, CancellationToken cancellationToken);
        public Task<List<Image>> GetAllByPostsIdsAsync(List<Guid> images, CancellationToken cancellationToken);
    }
}
