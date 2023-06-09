using Domain.Entities;

namespace Domain.Repositories
{
    public interface IReactionRepository
    {
        void Add(Reaction reaction);
        void Remove(Reaction reaction);
        void Update(Reaction reaction);
    }
}
