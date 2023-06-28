using Domain.Entities;
using Domain.Primitives;
using Domain.Shared;
using ValueObjectErrors = Domain.Errors.DomainErrors.ValueObjects;

namespace Domain.ValueObjects
{
    public class ReactionType : ValueObject
    {
        private ReactionType(string value)
        {
            Value = value;
        }
        private ReactionType() { }

        public string Value { get; }
        public static implicit operator string(ReactionType type) => type.Value ?? string.Empty;
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
        public static Result<ReactionType> Create(string reactionType)
        {
            if (string.IsNullOrEmpty(reactionType))
                return Result.Failure<ReactionType>(ValueObjectErrors.ReactionNotFound);

            if (!Enum.IsDefined(typeof(ReactionTypeEnum), reactionType))
                return Result.Failure<ReactionType>(ValueObjectErrors.ReactionNotDefined);

            return new ReactionType(reactionType);
        }
    }
}
