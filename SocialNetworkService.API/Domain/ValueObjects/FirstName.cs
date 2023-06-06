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
                return Result.Failure<FirstName>(new Error(
                    "FirstName.Empty",
                    "First name is empty."));            

            if (firstName.Length > MaxLenght)
                return Result.Failure<FirstName>(new Error(
                    "FirstName.TooLong",
                    "First name is too long."));

            return new Result<FirstName>(new FirstName(firstName), true, Error.None);
        }
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
