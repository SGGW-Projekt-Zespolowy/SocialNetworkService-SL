using Domain.Entities;

namespace Domain.Repositories
{
    public interface IBadgeRepository
    {
        void Add(Badge badge);
        void Remove(Badge badge);
        void Update(Badge badge);
    }
}
