namespace Infrastructure.Specifications.Publication
{
    public sealed class PublicationByUseriIdSpecification: Specification<Domain.Entities.Publication>
    {
        public PublicationByUseriIdSpecification(Guid userId): 
            base(x => x.AuthorId == userId || x.CoAuthors.Select(y => y.UserId).Contains(userId))
        {
            AddInclude(x => x.CoAuthors);                
        }
    }
}
