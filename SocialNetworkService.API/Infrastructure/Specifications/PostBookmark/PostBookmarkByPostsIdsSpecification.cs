namespace Infrastructure.Specifications.PostBookmark
{
    public sealed class PostBookmarkByPostsIdsSpecification: Specification<Domain.Entities.PostBookmark>
    {
        public PostBookmarkByPostsIdsSpecification(List<Guid> postIds):
            base(x => postIds.Contains(x.PostId))
        {                
        }
    }
}
