using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class PostRepository : IPostRepository
    {
        private readonly DatabaseContext _dbContext;
        public void Add(Post post)
        {
            _dbContext.Set<Post>().Add(post);
        }

        public async Task<Post?> GetByIdWithAllAsync(Guid id)
        {
            return await _dbContext.Set<Post>()
                .Include(x => x.Hashtags)
                .Include(x => x.Reactions)
                .Include(x => x.Comments)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(Post post)
        {
            _dbContext.Set<Post>().Remove(post);
        }

        public void Update(Post post)
        {
            _dbContext.Set<Post>().Update(post);
        }
    }
}
