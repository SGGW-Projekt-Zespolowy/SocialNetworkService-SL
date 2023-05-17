using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Specialization : Entity
    {
        public Specialization(Guid id, MedicalSpecializationEnum specialization) : base(id)
        {
            this.MedicalSpecialization = specialization;
            AuthorId = authorId;
        }

        public MedicalSpecializationEnum specialization { get; set; }
    }
}
