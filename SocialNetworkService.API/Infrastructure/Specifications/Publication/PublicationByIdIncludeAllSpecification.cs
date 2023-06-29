using Domain.Entities;

namespace Infrastructure.Specifications
{
    public class PublicationByIdIncludeAllSpecification : Specification<Domain.Entities.Publication>
    {
        public PublicationByIdIncludeAllSpecification(Guid id)
            : base(x => x.Id == id) 
        {
            AddInclude(publication => publication.CoAuthors);
        }
    }
}