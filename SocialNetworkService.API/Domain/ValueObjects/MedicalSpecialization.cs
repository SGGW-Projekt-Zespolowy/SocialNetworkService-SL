using Domain.Entities;
using Domain.Primitives;
using Domain.Shared;


namespace Domain.ValueObjects
{
    public class MedicalSpecialization : ValueObject
    {
        public const int MaxTypeLength = 50;
        private MedicalSpecialization(string value)
        {
            Value = value;
        }
        private MedicalSpecialization() { }

        public string Value { get; private set; }

        public static implicit operator string(MedicalSpecialization spec) => spec.Value ?? string.Empty;

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
        public static Result<MedicalSpecialization> Create(string medicalSpecialization)
        {
            if (string.IsNullOrEmpty(medicalSpecialization))
                return Result.Failure<MedicalSpecialization>(new Error(
                    "MedicalSpecialization.Empty",
                    "MedicalSpecialization is empty."));

            if (medicalSpecialization.Length > MaxTypeLength)
                return Result.Failure<MedicalSpecialization>(new Error(
                    "MedicalSpecialization.TooLongName",
                    "MedicalSpecialization is too long."));

            if (!Enum.IsDefined(typeof(MedicalSpecializationEnum), medicalSpecialization))
                return Result.Failure<MedicalSpecialization>(new Error(
                    "MedicalSpecialization.NotDefined",
                    "MedicalSpecialization is not defined."));

            return new MedicalSpecialization(medicalSpecialization);
        }
    }
}
