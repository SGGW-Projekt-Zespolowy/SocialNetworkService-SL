using Domain.ValueObjects;

namespace Application.Publications.Queries.GetPublicationById
{
    public record GetPublicationByIdResponse(
        Guid id, Guid authorId, Title title, string content, 
        Link link, string picture, MedicalSpecialization type);
}
