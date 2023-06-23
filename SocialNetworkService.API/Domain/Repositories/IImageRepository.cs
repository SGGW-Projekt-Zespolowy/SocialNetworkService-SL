using Domain.Entities;

namespace Domain.Repositories
{
    public interface IImageRepository
    {
        public void Add(Image image);
        public Task Delete(Guid imageId);
        public Task<List<Image>> GetAllByPostIdAsync(Guid postId);

    }
}
