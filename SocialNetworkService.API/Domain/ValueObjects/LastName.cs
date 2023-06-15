using Domain.Primitives;
using Domain.Shared;
using ValueObjectErrors = Domain.Errors.DomainErrors.ValueObjects;

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
                return Result.Failure<LastName>(ValueObjectErrors.LastNameNotFound);

            if (lastName.Length > MaxNameLength)
                return Result.Failure<LastName>(ValueObjectErrors.LastNameTooLong);

            return new LastName(lastName);
        }
    }
}
