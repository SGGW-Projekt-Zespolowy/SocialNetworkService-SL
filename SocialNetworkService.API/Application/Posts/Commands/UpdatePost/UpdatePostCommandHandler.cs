using Application.Abstractions;
using Domain.Repositories;
using Domain.Shared;
using Domain.ValueObjects;
using ValueObjectErrors = Domain.Errors.DomainErrors.ValueObjects;

namespace Application.Posts.Commands.UpdatePost
{
    public class UpdatePostCommandHandler
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePostCommandHandler(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.postId, cancellationToken);
            if (post is null)
            {
                return Result.Failure(Domain.Errors.ApplicationErrors.Post.PostNotFound(request.postId));
            }

            var content = request.content != string.Empty ? Content.Create(request.content) : null;
            var type = request.type != string.Empty ? MedicalSpecialization.Create(request.type) : null;
            var title = request.title != string.Empty ? Title.Create(request.title) : null;

            if (content is not null && content.IsFailure) return Result.Failure(ValueObjectErrors.ContentIsInvalid);
            if (type is not null && type.IsFailure) return Result.Failure(ValueObjectErrors.TypeIsInvalid);
            if (title is not null && title.IsFailure) return Result.Failure(ValueObjectErrors.TitleIsInvalid);

            post.Update(content?.Value, type?.Value, title?.Value);
            _postRepository.Update(post, cancellationToken);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
