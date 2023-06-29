namespace Infrastructure.Specifications.Reaction
{
    public sealed class ReactionByPostIdsSpecification: Specification<Domain.Entities.Reaction>
    {
        public ReactionByPostIdsSpecification(List<Guid> postIds): 
            base(x => postIds.Contains(x.RelatedItemId))
        {                
        }
    }
}
