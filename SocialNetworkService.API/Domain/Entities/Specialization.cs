using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Specialization : Entity
    {
        public Specialization(Guid id, MedicalSpecialization specialization) : base(id)
        {
            this.specialization = specialization;
        }

        public MedicalSpecialization specialization { get; set; }
    }
}
