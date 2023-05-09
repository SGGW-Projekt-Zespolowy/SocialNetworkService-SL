using Domain.Entities;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects
{
    public class Degree : ValueObject
    {
        public const int MaxDegreeLength = 50;
        private Degree(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
        public Result<Degree> Create(string degree)
        {
            if (string.IsNullOrEmpty(degree))
                return Result.Failure<Degree>(new Error(
                    "Degree.Empty",
                    "Degree of user is empty."));

            if (degree.Length > MaxDegreeLength)
                return Result.Failure<Degree>(new Error(
                    "Degree.TooLongName",
                    "Degree of user is too long."));

            if (!Enum.IsDefined(typeof(DegreeEnum), degree))
                return Result.Failure<Degree>(new Error(
                    "Degree.NotDefined",
                    "Degree of user is not defined."));

            return new Degree(degree);
        }
    }
}
