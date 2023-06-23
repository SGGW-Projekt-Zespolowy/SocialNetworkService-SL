using Application.Abstractions.Messaging;

namespace Application.Publications.Queries.GetPublicationById
{
    public record GetPublicationByIdWithAllQuery(Guid publicationId) : IQuery<GetPublicationByIdWithAllResponse>;
}
