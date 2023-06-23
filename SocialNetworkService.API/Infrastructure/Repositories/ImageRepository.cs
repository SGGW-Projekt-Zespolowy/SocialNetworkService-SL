using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public sealed class ImageRepository : IImageRepository
    {
        private readonly DatabaseContext _dbContext;

        public ImageRepository(DatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }

        public void Add(Image image)
        {
            _dbContext.Set<Image>().Add(image);
        }

        public async Task Delete(Guid imageId)
        {
            var image = await _dbContext.Set<Image>().FirstOrDefaultAsync(x => imageId == x.Id);
            if (image is not null)
                _dbContext.Remove(image);
        }

        public async Task<List<Image>> GetAllByPostIdAsync(Guid postId)
        {
            var images = await _dbContext.Set<Image>().Where(x => x.PostId == postId).ToListAsync();
            return images;
        }
    }
}
