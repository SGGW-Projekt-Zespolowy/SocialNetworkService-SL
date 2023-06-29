

namespace Infrastructure.Specifications.Image
{
    public sealed class ImagesByPostIdsSpecification: Specification<Domain.Entities.Image>
    {
        public ImagesByPostIdsSpecification(List<Guid> imageIds):
            base(x => imageIds.Contains(x.PostId))
        {                
        }
    }
}
