using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Repositories
{
    internal class CommentRepository : ICommentRepository
    {
        private readonly DatabaseContext _dbContext;

        public CommentRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Comment comment)
        {
            _dbContext.Set<Comment>().Add(comment);
        }

        public async Task<Comment?> GetByIdWithAllAsync(Guid id)
        {
            return await _dbContext.Set<Comment>()
                .Include(x => x.Comments)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(Comment comment)
        {
            _dbContext.Set<Comment>().Remove(comment);
        }

        public void Update(Comment comment)
        {
            _dbContext.Set<Comment>().Update(comment);
        }
    }
}
