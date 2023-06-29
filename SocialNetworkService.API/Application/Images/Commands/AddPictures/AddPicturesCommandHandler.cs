using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Entities;
using Domain.Repositories;
using Domain.Shared;
using System.Windows.Input;

namespace Application.Images.Commands.AddPicture
{
    public sealed class AddPicturesCommandHandler : ICommandHandler<AddPicturesCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageRepository _imageRepository;
        private readonly IPostRepository _postRepository;

        public AddPicturesCommandHandler(IUnitOfWork unitOfWork, IImageRepository imageRepository, IPostRepository postRepository)
        {
            _unitOfWork = unitOfWork;
            _imageRepository = imageRepository;
            _postRepository = postRepository;
        }

        public async Task<Result> Handle(AddPicturesCommand request, CancellationToken cancellationToken)
        {
            if (!await _postRepository.Exists(request.postId))
                return Result.Failure(Domain.Errors.ApplicationErrors.Post.PostNotFound(request.postId));

            foreach (var file in request.images)
            {
                var image = Image.Encode(file, request.postId);
                if (image.IsFailure)
                    return Result.Failure(image.Error);

                _imageRepository.Add(image.Value, cancellationToken);
            }
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
