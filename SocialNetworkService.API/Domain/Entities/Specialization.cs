using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Specialization : Entity
    {
        public Specialization(Guid id, MedicalSpecializationEnum specialization, Guid authorId) : base(id)
        {
            MedicalSpecialization = specialization;
            AuthorId = authorId;
        }
        private Specialization() { }
        public MedicalSpecializationEnum MedicalSpecialization { get; set; }
        public User User { get; private set; }
        public Guid AuthorId { get; set; }
    }
}
