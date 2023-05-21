using Domain.Primitives;
using Domain.Shared;

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

        public Result<Title> Create(string title)
        {
            if (string.IsNullOrEmpty(title))
                return Result.Failure<Title>(new Error(
                        "Title.Empty",
                        "Title is empty."));

            if (title.Length > MaxTitleLength)
                return Result.Failure<Title>(new Error(
                    "Title.TooLong",
                    "Title is too long."));

            return new Title(title);
        }
    }
}
