using Domain.Entities;

namespace Domain.Repositories
{
    public interface IReactionRepository
    {
        Task<List<Reaction>> GetByRelatedItemId(Guid relatedItemId, CancellationToken cancellationToken);
        Task<List<Reaction>?> GetByPostIdsAsync(List<Guid> postIds, CancellationToken cancellationToken);
        Task<Reaction?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        void Add(Reaction reaction, CancellationToken cancellationToken);
        void Remove(Reaction reaction, CancellationToken cancellationToken);
        void Update(Reaction reaction, CancellationToken cancellationToken);
        Task<Reaction?> GetByPostIdAndAuthorIdAsync(Guid postId, Guid authorId, CancellationToken cancellationToken);
    }
}
