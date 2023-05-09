using Domain.Primitives;
using Domain.Shared;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public class Link : ValueObject
    {
        public const int MaxLinkLength = 60;
        Regex linkRegex = new Regex(@"^(http|https)://[a-z0-9\-\.]+\.[a-z]{2,}/?.*$");


        private Link(string value)
        {
            Value = value;
        }
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        public string Value { get; }

        public Result<Link> Create(string link)
        {
            if (string.IsNullOrEmpty(link))
                return Result.Failure<Link>(new Error(
                    "Link.Empty",
                    "Link is null or empty."));

            if (link.Length > MaxLinkLength)
                return Result.Failure<Link>(new Error(
                    "Link.TooLong",
                    "Link is too long."));

            if (!linkRegex.IsMatch(link))
                return Result.Failure<Link>(new Error(
                    "Link.Incorrect",
                    "Link is incorrect."));

            return new Link(link);
        }
    }
}
