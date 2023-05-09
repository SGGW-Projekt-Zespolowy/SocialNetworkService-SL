using Domain.Entities;
using Domain.Primitives;
using Domain.Shared;


namespace Domain.ValueObjects
{
    public class Type : ValueObject
    {
        public const int MaxTypeLength = 50;
        private Type(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
        public Result<Type> Create(string type)
        {
            if (string.IsNullOrEmpty(type))
                return Result.Failure<Type>(new Error(
                    "Type.Empty",
                    "Type is empty."));

            if (type.Length > MaxTypeLength)
                return Result.Failure<Type>(new Error(
                    "Type.TooLongName",
                    "Type is too long."));

            if (!Enum.IsDefined(typeof(MedicalSpecialization), type))
                return Result.Failure<Type>(new Error(
                    "Type.NotDefined",
                    "Type is not defined."));

            return new Type(type);
        }
    }
}
