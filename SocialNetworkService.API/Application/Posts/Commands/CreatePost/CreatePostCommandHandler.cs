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

        public CreatePostCommandHandler(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
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

            var post = new Post(id, authorId, content.Value, type.Value, title.Value);

            _postRepository.Add(post, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
