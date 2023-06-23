using Application.Abstractions.Messaging;

namespace Application.Images.Queries.GetImagesByPostId
{
    public record GetImagesByPostIdQuery(Guid postId): IQuery<GetImagesByPostIdQueryResponse>;
}
