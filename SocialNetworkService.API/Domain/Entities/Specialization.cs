using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Specialization : Entity
    {
        public Specialization(Guid id, MedicalSpecializationEnum specialization) : base(id)
        {
            this.specialization = specialization;
        }

        public MedicalSpecializationEnum specialization { get; set; }
    }
}
