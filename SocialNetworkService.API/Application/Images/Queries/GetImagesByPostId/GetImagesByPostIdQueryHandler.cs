using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Entities;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Images.Queries.GetImagesByPostId
{
    public sealed class GetImagesByPostIdQueryHandler : IQueryHandler<GetImagesByPostIdQuery, GetImagesByPostIdQueryResponse>
    {
        private IUnitOfWork _unitOfWork;
        private IImageRepository _imageRepository;

        public GetImagesByPostIdQueryHandler(IUnitOfWork unitOfWork, IImageRepository imageRepository)
        {
            _unitOfWork = unitOfWork;
            _imageRepository = imageRepository;
        }

        public async Task<Result<GetImagesByPostIdQueryResponse>> Handle(GetImagesByPostIdQuery query, CancellationToken cancellationToken)
        {
            var images = await _imageRepository.GetAllByPostIdAsync(query.postId, cancellationToken);
            if (images is null)
                return Result.Failure<GetImagesByPostIdQueryResponse>
                    (Domain.Errors.ApplicationErrors.Image.ImagesNotFound(query.postId));

            var response = new GetImagesByPostIdQueryResponse(new List<ImageResponse> { });
            foreach(var image in images)
            {
                var readableData = ImageResponse.Decode(image);
                if (readableData.IsFailure)
                    return Result.Failure<GetImagesByPostIdQueryResponse>(readableData.Error);

                response.Add(readableData.Value);
            }
            
            return response;
        }
    }
}
