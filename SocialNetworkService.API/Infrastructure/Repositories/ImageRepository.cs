using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Specifications;
using Infrastructure.Specifications.Image;
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

        public void Add(Image image, CancellationToken cancellationToken)
        {
            _dbContext.Set<Image>().Add(image);
        }

        public async Task Delete(Guid imageId, CancellationToken cancellationToken)
        {
            var image = await _dbContext.Set<Image>().FirstOrDefaultAsync(x => imageId == x.Id);
            if (image is not null)
                _dbContext.Remove(image);
        }
        public IQueryable<Image> ApplySpecification(Specification<Image> specification)
        {
            return SpecificationEvaluator.GetQuery(_dbContext.Set<Image>(), specification);
        }

        public async Task<List<Image>> GetAllByPostIdAsync(Guid postId, CancellationToken cancellationToken)
        {
            var images = await _dbContext.Set<Image>().Where(x => x.PostId == postId).ToListAsync(cancellationToken);
            return images;
        }

        public async Task<List<Image>> GetAllByPostsIdsAsync(List<Guid> images, CancellationToken cancellationToken)
            => await ApplySpecification(new ImagesByPostIdsSpecification(images)).ToListAsync(cancellationToken);
    }
}
