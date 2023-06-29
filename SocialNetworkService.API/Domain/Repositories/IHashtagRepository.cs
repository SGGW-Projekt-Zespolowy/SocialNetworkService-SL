using Domain.Entities;

namespace Domain.Repositories
{
    public interface IHashtagRepository
    {
        void Add(Hashtag hashtag, CancellationToken cancellationToken);
        void Remove(Hashtag hashtag, CancellationToken cancellationToken);
        void Update(Hashtag hashtag, CancellationToken cancellationToken);
        Task<List<Hashtag>> GetAllByIdsAsync(List<Guid>? postIds, CancellationToken cancellationToken);
    }
}
