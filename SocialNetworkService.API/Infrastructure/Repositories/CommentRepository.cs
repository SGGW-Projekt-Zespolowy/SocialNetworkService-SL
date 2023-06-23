using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Specifications;
using Infrastructure.Specifications.Comment;
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

        public void Add(Comment comment, CancellationToken cancellationToken)
        {
            _dbContext.Set<Comment>().Add(comment);
        }

        public async Task<Comment?> GetByIdWithAllAsync(Guid id, CancellationToken cancellationToken)
            => await ApplySpecification(new CommentByIdIncludeAllSpecification(id)).FirstOrDefaultAsync(cancellationToken);

        public async Task<Comment?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => await ApplySpecification(new CommentByIdSpecification(id)).FirstOrDefaultAsync(cancellationToken);


        public IQueryable<Comment> ApplySpecification(Specification<Comment> specification)
        {
            return SpecificationEvaluator.GetQuery(_dbContext.Set<Comment>(), specification);
        }

        public void Remove(Comment comment, CancellationToken cancellationToken)
        {
            _dbContext.Set<Comment>().Remove(comment);
        }

        public void Update(Comment comment, CancellationToken cancellationToken)
        {
            _dbContext.Set<Comment>().Update(comment);
        }
    }
}
