using Domain.Entities;

namespace Infrastructure.Specifications
{
    public class PublicationByIdSpecification : Specification<Domain.Entities.Publication>
    {
        public PublicationByIdSpecification(Guid id)
            : base(publication => publication.Id == id) { }
    }
}


