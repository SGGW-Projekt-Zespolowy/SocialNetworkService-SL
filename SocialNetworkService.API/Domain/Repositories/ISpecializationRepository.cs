using Domain.Entities;

namespace Domain.Repositories
{
    public interface ISpecializationRepository
    {
        void Add(Specialization specialization);
        void Remove(Specialization specialization);
        void Update(Specialization specialization);       
    }
}
