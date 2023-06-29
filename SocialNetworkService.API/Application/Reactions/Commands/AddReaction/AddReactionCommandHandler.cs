using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Entities;
using Domain.Repositories;
using Domain.Shared;
using Domain.ValueObjects;

namespace Application.Reactions.Commands.AddReaction
{
    public sealed class AddReactionCommandHandler : ICommandHandler<AddReactionCommand>
    {
        private readonly IReactionRepository _reactionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddReactionCommandHandler(IReactionRepository reactionRepository, IUnitOfWork unitOfWork)
        {
            _reactionRepository = reactionRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(AddReactionCommand request, CancellationToken cancellationToken)
        {
            var dbReaction = _reactionRepository.GetByPostIdAndAuthorIdAsync(request.relatedItemId,request.authorId,cancellationToken);
            if (dbReaction is not null)
                return Result.Failure(Domain.Errors.ApplicationErrors.Reaction.ReactionAlreadyExists(request.relatedItemId));

            var id = new Guid();
            var reactionType = ReactionType.Create(request.reactionType);
            if (reactionType.IsFailure)
                return Result.Failure(reactionType.Error);
            var relatedItemId = request.relatedItemId;
            var authorId = request.authorId;

            var reaction = new Reaction(id, reactionType.Value, relatedItemId, authorId);

            _reactionRepository.Add(reaction, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
