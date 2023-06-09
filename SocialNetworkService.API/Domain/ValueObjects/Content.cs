using Domain.Entities;
using Domain.Primitives;
using Domain.Shared;
using ValueObjectErrors = Domain.Errors.DomainErrors.ValueObjects;

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

        public Result<Content> Create(string content)
        {
            if (string.IsNullOrEmpty(content))
                return Result.Failure<Content>(ValueObjectErrors.ContentNotFound);

            if (content.Length > MaxContentLength)
                return Result.Failure<Content>(ValueObjectErrors.ContentTooLong);

            return new Content(content);
        }
    }
}
