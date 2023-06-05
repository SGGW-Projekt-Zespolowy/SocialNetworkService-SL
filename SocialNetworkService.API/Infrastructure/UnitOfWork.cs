
using Application.Abstractions;

namespace Infrastructure
{
    public sealed class UnitOfWork: IUnitOfWork
    {
        private readonly DatabaseContext _dbContext;

        public UnitOfWork(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }           
        
    }
}
