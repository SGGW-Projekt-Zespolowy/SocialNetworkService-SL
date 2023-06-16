using Domain.Primitives;
using Domain.Shared;
using ValueObjectErrors = Domain.Errors.DomainErrors.ValueObjects;

namespace Domain.ValueObjects
{
    public class Title : ValueObject
    {
        public const int MaxTitleLength = 100;
        private Title(string value)
        {
            Value = value;
        }
        private Title() { }
        public string Value { get; }
        public static implicit operator string(Title title ) => title.Value ?? string.Empty;
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        public static Result<Title> Create(string title)
        {
            if (string.IsNullOrEmpty(title))
                return Result.Failure<Title>(ValueObjectErrors.TitleNotFound);

            if (title.Length > MaxTitleLength)
                return Result.Failure<Title>(ValueObjectErrors.TitleTooLong);

            return new Title(title);
        }
    }
}
