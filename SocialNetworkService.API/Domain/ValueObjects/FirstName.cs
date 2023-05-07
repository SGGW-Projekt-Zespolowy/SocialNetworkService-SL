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
        public string Value { get; }
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

            return new FirstName(firstName);
        }
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
