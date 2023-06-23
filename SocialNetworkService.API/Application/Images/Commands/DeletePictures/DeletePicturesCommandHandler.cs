using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Images.Commands.DeletePictures
{
    public sealed class DeletePicturesCommandHandler : ICommandHandler<DeletePicturesCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageRepository _imageRepository;

        public DeletePicturesCommandHandler(IUnitOfWork unitOfWork, IImageRepository imageRepository)
        {
            _unitOfWork = unitOfWork;
            _imageRepository = imageRepository;
        }

        public async Task<Result> Handle(DeletePicturesCommand request, CancellationToken cancellationToken)
        {
            foreach(var pictureId in request.imageIds)
            {
                await _imageRepository.Delete(pictureId, cancellationToken);
            }
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
