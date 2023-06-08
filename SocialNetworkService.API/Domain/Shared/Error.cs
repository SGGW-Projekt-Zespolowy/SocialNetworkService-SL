using Domain.Primitives;

namespace Domain.Shared
{
    /// <summary>
    /// Represents a concrete domain error.
    /// </summary>
    public class Error : ValueObject
    {
        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public string Code { get; }

        public string Message { get; }

        public static implicit operator string(Error error) => error?.Code ?? string.Empty;

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Code;
            yield return Message;
        }

        public static readonly Error None = new Error(string.Empty, string.Empty);
    }
}
