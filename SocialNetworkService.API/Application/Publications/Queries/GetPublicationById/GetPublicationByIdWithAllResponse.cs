using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Publications.Queries.GetPublicationById
{
    public record GetPublicationByIdWithAllResponse(
        Guid id, Guid authorId, Title title, string content,
        Link link, string picture, MedicalSpecialization type,
        List<CoAuthor> coAuthors);
}
