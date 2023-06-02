using Domain.Entities;
using Domain.Primitives;
using Domain.Shared;

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
        public Result<ReactionType> Create(string reactionType)
        {
            if (string.IsNullOrEmpty(reactionType))
                return Result.Failure<ReactionType>(new Error(
                    "ReactionType.Empty",
                    "ReactionType is empty."));

            if (!Enum.IsDefined(typeof(ReactionTypeEnum), reactionType))
                return Result.Failure<ReactionType>(new Error(
                    "ReactionType.NotDefined",
                    "ReactionType is not defined."));

            return new ReactionType(reactionType);
        }
    }
}
