using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Repositories;
using Domain.Shared;
using Domain.ValueObjects;
using ValueObjectErrors = Domain.Errors.DomainErrors.ValueObjects;

namespace Application.Reactions.Commands.UpdateReaction
{
    public class UpdateReactionCommandHandler : ICommandHandler<UpdateReactionCommand>
    {
        private readonly IReactionRepository _reactionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateReactionCommandHandler(IReactionRepository reactionRepository, IUnitOfWork unitOfWork)
        {
            _reactionRepository = reactionRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(UpdateReactionCommand request, CancellationToken cancellationToken)
        {
            var reaction = await _reactionRepository.GetByIdAsync(request.id, cancellationToken);

            if (reaction is null)
            {
                return Result.Failure(Domain.Errors.ApplicationErrors.Reaction.ReactionNotFound(request.id));
            }

            var reactionType = request.reactionType != string.Empty ? ReactionType.Create(request.reactionType) : null;

            if (reactionType is not null && reactionType.IsFailure) return Result.Failure(ValueObjectErrors.ReactionNotDefined);

            reaction.Update(reactionType.Value);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
