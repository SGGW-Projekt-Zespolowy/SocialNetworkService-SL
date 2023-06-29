using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Specifications;
using Infrastructure.Specifications.PostBookmark;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public sealed class PostBookmarkRepository : IPostBookmarkRepository
    {
        private readonly DatabaseContext _dbContext;

        public PostBookmarkRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(PostBookmark postBookmark, CancellationToken cancellationToken)
        {
            _dbContext.Set<PostBookmark>().Add(postBookmark);
        }

        public async Task<List<PostBookmark>> GetAll(Guid userId, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<PostBookmark>().Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task Remove(PostBookmark postBookmark, CancellationToken cancellationToken)
        {
            var bookmark = await _dbContext.Set<PostBookmark>().FirstOrDefaultAsync(x => x.PostId == postBookmark.PostId 
                                                                                    && x.UserId == postBookmark.UserId);
            if (postBookmark is not null)
                _dbContext.Remove(postBookmark);
        }

        public async Task<PostBookmark?> GetByIdAsync(Guid postBookmarkId, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<PostBookmark>().FirstOrDefaultAsync(x => x.Id == postBookmarkId);
        }
        public IQueryable<PostBookmark> ApplySpecification(Specification<PostBookmark> specification)
        {
            return SpecificationEvaluator.GetQuery(_dbContext.Set<PostBookmark>(), specification);
        }

        public async Task<List<PostBookmark>> GetAllByPostIdsAsync(List<Guid> postIds, CancellationToken cancellationToken)
            => await ApplySpecification(new PostBookmarkByPostsIdsSpecification(postIds)).ToListAsync(cancellationToken);
    }
}
