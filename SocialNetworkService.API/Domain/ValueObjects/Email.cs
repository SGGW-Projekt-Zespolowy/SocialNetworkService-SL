using Domain.Primitives;
using Domain.Shared;
using System.Text.RegularExpressions;

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
                return Result.Failure<Email>(new Error(
                    "Email.Empty",
                    "Email is empty"));

            if (email.Length > MaxEmailLenght)
                return Result.Failure<Email>(new Error(
                    "Email.TooLong",
                    "Email is too long."));

            if (!ValidateEmail(email))
                return Result.Failure<Email>(new Error("" +
                    "Email.Invalid",
                    "Email is invalid."));

            return new Email(email);
        }

        private static bool ValidateEmail(string email)
        {
            var validation = new Regex("\\S+@\\w+[.]\\w+");
            return validation.Match(email).Success;
        }
    }
}
