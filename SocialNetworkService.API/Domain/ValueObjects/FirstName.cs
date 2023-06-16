using Domain.Primitives;
using Domain.Shared;
using ValueObjectErrors = Domain.Errors.DomainErrors.ValueObjects;

namespace Domain.ValueObjects
{
    public sealed class FirstName: ValueObject
    {
        public const int MaxLenght = 50;
        private FirstName(string value)
        {
            Value = value;
        }
        private FirstName() { }
        public string Value { get; }
        public static implicit operator string(FirstName firstName) => firstName.Value ?? string.Empty;
        public static Result<FirstName> Create(string firstName)
        {
            if (string.IsNullOrEmpty(firstName))            
                return Result.Failure<FirstName>(ValueObjectErrors.FirstNameNotFound);            

            if (firstName.Length > MaxLenght)
                return Result.Failure<FirstName>(ValueObjectErrors.FirstNameTooLong);

            return new Result<FirstName>(new FirstName(firstName), true, Error.None);
        }
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
