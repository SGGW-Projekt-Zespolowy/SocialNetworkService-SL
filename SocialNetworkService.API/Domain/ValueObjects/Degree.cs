using Domain.Entities;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects
{
    public class Degree : ValueObject
    {
        private Degree(string value)
        {
            Value = value;
        }
        private Degree() { }
        public string Value { get; }
        public static implicit operator string(Degree degree) => degree.Value ?? string.Empty;
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
        public static Result<Degree> Create(string degree)
        {
            if (string.IsNullOrEmpty(degree))
                return Result.Failure<Degree>(new Error(
                    "Degree.Empty",
                    "Degree of user is empty."));

            if (!Enum.IsDefined(typeof(DegreeEnum), degree))
                return Result.Failure<Degree>(new Error(
                    "Degree.NotDefined",
                    "Degree of user is not defined."));

            return new Degree(degree);
        }
    }
}
