using Domain.Primitives;
using Domain.Shared;
using System.Text.RegularExpressions;
using ValueObjectErrors = Domain.Errors.DomainErrors.ValueObjects;

namespace Domain.ValueObjects
{
    public sealed class Email : ValueObject
    {
        public const int MaxEmailLenght = 50;
        private Email(string value)
        {
            Value = value;
        }
        private Email() { }
        public string Value { get; }
        public static implicit operator string(Email email) => email.Value ?? string.Empty;
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        public static Result<Email> Create(string email)
        {
            if (string.IsNullOrEmpty(email))
                return Result.Failure<Email>(ValueObjectErrors.EmailNotFound);

            if (email.Length > MaxEmailLenght)
                return Result.Failure<Email>(ValueObjectErrors.EmailTooLong);

            if (!ValidateEmail(email))
                return Result.Failure<Email>(ValueObjectErrors.EmailIsInvalid);

            return new Email(email);
        }

        private static bool ValidateEmail(string email)
        {
            var validation = new Regex("\\S+@\\w+[.]\\w+");
            return validation.Match(email).Success;
        }
    }
}
