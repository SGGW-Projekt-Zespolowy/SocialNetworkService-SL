using Application.Posts.Queries.GetPostById;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly DatabaseContext _dbContext;

        public PostRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Post post, CancellationToken cancellationToken)
        {
            _dbContext.Set<Post>().Add(post);
        }

        public async Task<Post?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await ApplySpecification(new PostByIdSpecification(id)).FirstOrDefaultAsync(cancellationToken);
        public async Task<Post?> GetByIdWithAllAsync(Guid id, CancellationToken cancellationToken)
        => await ApplySpecification(new PostByIdIncludeAllSpecification(id)).FirstOrDefaultAsync(cancellationToken);

        public IQueryable<Post> ApplySpecification(Specification<Post> specification)
        {
            return SpecificationEvaluator.GetQuery(_dbContext.Set<Post>(), specification);
        }

        public void Remove(Post post, CancellationToken cancellationToken)
        {
            _dbContext.Set<Post>().Remove(post);
        }

        public void Update(Post post, CancellationToken cancellationToken)
        {
            _dbContext.Set<Post>().Update(post);
        }

        public async Task<List<Post>> GetAll(int page, int pageSize, CancellationToken cancellationToken)
        {
            IQueryable<Post> postsQuery = _dbContext.Set<Post>();
            var posts = await postsQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Include(p => p.Comments)
                .ToListAsync(cancellationToken);

            return posts;
        }
        public async Task<bool> Exists(Guid id)
        {
            return await _dbContext.Set<Post>().AnyAsync(x => x.Id == id);
        }
    }
}
