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

        public string Value { get; }
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
        public Result<LastName> Create(string lastName)
        {
            if (string.IsNullOrEmpty(Value))
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
