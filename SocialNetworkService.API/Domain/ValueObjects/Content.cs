using Domain.Entities;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects
{
    public class Content : ValueObject
    {
        public const int MaxContentLength = 30000;
        private Content(string value) 
        {
            Value = value;
        }
        private Content() { }
        public string Value { get; }
        public static implicit operator string(Content content) => content.Value ?? string.Empty;
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        public static Result<Content> Create(string content)
        {
            if (string.IsNullOrEmpty(content))
                return Result.Failure<Content>(new Error(
                        "Content.Empty",
                        "Content is empty."));

            if (content.Length > MaxContentLength)
                return Result.Failure<Content>(new Error(
                    "Content.TooLong",
                    "Content is too long."));

            return new Content(content);
        }
    }
}
