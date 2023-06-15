using Domain.Primitives;
using Domain.Shared;
using System.Text.RegularExpressions;
using ValueObjectErrors = Domain.Errors.DomainErrors.ValueObjects;

namespace Domain.ValueObjects
{
    public class Link : ValueObject
    {
        public const int MaxLinkLength = 60;
        static Regex linkRegex = new Regex(@"^(http|https)://[a-z0-9\-\.]+\.[a-z]{2,}/?.*$");


        private Link(string value)
        {
            Value = value;
        }
        private Link() { }
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        public string Value { get; }
        public static implicit operator string(Link link) => link.Value ?? string.Empty;
        public static Result<Link> Create(string link)
        {
            if (string.IsNullOrEmpty(link))
                return Result.Failure<Link>(ValueObjectErrors.LinkNotFound);

            if (link.Length > MaxLinkLength)
                return Result.Failure<Link>(ValueObjectErrors.LinkTooLong);

            if (!linkRegex.IsMatch(link))
                return Result.Failure<Link>(ValueObjectErrors.LinkIsInvalid);

            return new Link(link);
        }
    }
}
