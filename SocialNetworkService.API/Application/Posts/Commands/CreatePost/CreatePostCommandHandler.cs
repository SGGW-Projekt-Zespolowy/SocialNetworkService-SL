using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Entities;
using Domain.Repositories;
using Domain.Shared;
using Domain.ValueObjects;
namespace Application.Posts.Commands.CreatePost
{
    public sealed class CreatePostCommandHandler : ICommandHandler<CreatePostCommand>
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IHashtagRepository _hashtagRepository;
        //private readonly IImageRepository _imageRepository;

        public CreatePostCommandHandler(IPostRepository postRepository, IUnitOfWork unitOfWork /*,IHashtagRepository hashtagRepository, IImageRepository imageRepository*/ )
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
            //_hashtagRepository = hashtagRepository;
            //_imageRepository = imageRepository;
        }
        public async Task<Result> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var id = new Guid();
            var authorId = request.authorId;
            var content = Content.Create(request.content);
            if (content.IsFailure)
                return Result.Failure(content.Error);
            var type = MedicalSpecialization.Create(request.type);
            if (type.IsFailure)
                return Result.Failure(type.Error);
            var title = Title.Create(request.title);
            if (title.IsFailure)
                return Result.Failure(title.Error);

            var post = new Post(id, authorId, content.Value, type.Value, title.Value,false);
            _postRepository.Add(post, cancellationToken);

            //if (request.hashtags.Count > 0)
            //{
            //    var availableHashtags = request.hashtags.Where(x => !string.IsNullOrEmpty(x)).ToList();
            //    foreach(var hashtag in availableHashtags)
            //    {
            //        var hashtagObj = new Hashtag(Guid.NewGuid(), hashtag, id);
            //        _hashtagRepository.Add(hashtagObj,cancellationToken);
            //    }
            //}

            //foreach (var file in request.images)
            //{
            //    var image = Image.Encode(file, id);
            //    if (image.IsFailure)
            //        return Result.Failure(image.Error);

            //    _imageRepository.Add(image.Value, cancellationToken);
            //}

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
