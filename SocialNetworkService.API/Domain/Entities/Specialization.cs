using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Specialization : Entity
    {
        public Specialization(Guid id, MedicalSpecialization specialization, Guid authorId) : base(id)
        {
            this.MedicalSpecialization = specialization;
            AuthorId = authorId;
        }
        public Guid AuthorId { get; init; }
        public MedicalSpecialization MedicalSpecialization { get; set; }
    }
}
