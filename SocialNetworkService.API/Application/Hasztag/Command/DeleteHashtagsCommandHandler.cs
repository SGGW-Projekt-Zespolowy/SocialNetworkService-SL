using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Hasztag.Command
{
    public sealed class DeleteHashtagsCommandHandler : ICommandHandler<DeleteHashtagsCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHashtagRepository _repository;

        public DeleteHashtagsCommandHandler(IUnitOfWork unitOfWork, IHashtagRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<Result> Handle(DeleteHashtagsCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                return Result.Failure(Domain.Errors.ApplicationErrors.General.BadRequest);

            var hashtags = await _repository.GetAllByIdsAsync(new List<Guid>() { request.postId }, cancellationToken);
            if(hashtags is not null)
                foreach(var hashtagId in request.hashtagIds)
                {
                    if (hashtags.Select(x => x.Id).Contains(hashtagId))
                        _repository.Remove(hashtags.FirstOrDefault(x => x.Id==hashtagId),cancellationToken);
                }

            return Result.Success();
        }
    }
}
