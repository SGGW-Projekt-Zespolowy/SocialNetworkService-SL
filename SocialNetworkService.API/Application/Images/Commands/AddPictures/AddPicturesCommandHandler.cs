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
                if (file.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        var base64 = Convert.ToBase64String(fileBytes);

                        var image = new Image(Guid.NewGuid(), base64, request.postId);
                        _imageRepository.Add(image, cancellationToken);
                    }
                }
            }
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
