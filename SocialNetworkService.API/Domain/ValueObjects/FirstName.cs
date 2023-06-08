using Domain.Primitives;
using Domain.Shared;

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
                return Result.Failure<FirstName>(Errors.DomainErrors.ValueObjects.FirstNameNotFound);            

            if (firstName.Length > MaxLenght)
                return Result.Failure<FirstName>(Errors.DomainErrors.ValueObjects.FirstNameTooLong);

            return new Result<FirstName>(new FirstName(firstName), true, Error.None);
        }
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
