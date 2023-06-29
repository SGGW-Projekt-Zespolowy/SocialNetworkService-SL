namespace Infrastructure.Specifications.Hashtag
{
    public sealed class HashtagByPostIdSpecification: Specification<Domain.Entities.Hashtag>
    {
        public HashtagByPostIdSpecification(List<Guid> postIds): 
            base(x => postIds.Contains(x.RelatedItemId))
        {               
        }
    }
}
