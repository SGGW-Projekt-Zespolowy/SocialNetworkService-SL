namespace Infrastructure.Specifications.Reaction
{
    public sealed class ReactionByRelatedItemAndAuthoerIdSpecification : Specification<Domain.Entities.Reaction>
    {
        public ReactionByRelatedItemAndAuthoerIdSpecification(Guid relatedItemId, Guid authorId)
            : base(x => x.RelatedItemId==relatedItemId && x.AuthorId==authorId)
        {                
        }
    }
}
