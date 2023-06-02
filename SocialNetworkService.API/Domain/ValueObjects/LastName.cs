using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects
{
    public sealed class LastName : ValueObject
    {
        public const int MaxNameLength = 50;
        private LastName(string value)
        {
            Value = value;
        }
        private LastName() { }
        public string Value { get; }
        public static implicit operator string(LastName lastName) => lastName.Value ?? string.Empty;
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
        public static Result<LastName> Create(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
                return Result.Failure<LastName>(new Error(
                        "LastName.Empty",
                        "First name is empty"));

            if (lastName.Length > MaxNameLength)
                return Result.Failure<LastName>(new Error(
                    "LastName.TooLongName",
                    "Last name is too long."));

            return new LastName(lastName);
        }
    }
}
