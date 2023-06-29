using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Publications.Queries.GetPublicationByUserId
{    
    public record GetPublicationByUserIdResponse(
        Guid id, Guid authorId, Title title, string content,
        Link link, MedicalSpecialization type, DateTime creationDate, List<CoAuthor> coAuthors);
}
