using Application.Abstractions.Messaging;

namespace Application.Publications.Queries.GetPublicationById
{
    public sealed record GetPublicationByIdQuery(Guid publicationId) : IQuery<GetPublicationByIdResponse>;
}
