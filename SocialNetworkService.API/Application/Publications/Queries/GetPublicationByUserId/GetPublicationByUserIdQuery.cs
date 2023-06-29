using Application.Abstractions.Messaging;

namespace Application.Publications.Queries.GetPublicationByUserId
{
    public record GetPublicationByUserIdQuery(Guid userId): IQuery<List<GetPublicationByUserIdResponse>>;
}
