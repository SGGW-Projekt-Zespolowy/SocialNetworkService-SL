
using Application.Abstractions;
using Domain.Primitives;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure
{
    internal sealed class UnitOfWork: IUnitOfWork
    {
        private readonly DatabaseContext _dbContext;

        public UnitOfWork(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }           
        
    }
}
