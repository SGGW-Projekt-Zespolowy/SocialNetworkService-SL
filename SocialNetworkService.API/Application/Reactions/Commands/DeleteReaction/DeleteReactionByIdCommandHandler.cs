using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Repositories;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reactions.Commands.DeleteReaction
{
    public class DeleteReactionByIdCommandHandler : ICommandHandler<DeleteReactionByIdCommand>
    {
        private readonly IReactionRepository _reactionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteReactionByIdCommandHandler(IReactionRepository reactionRepository, IUnitOfWork unitOfWork)
        {
            _reactionRepository = reactionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteReactionByIdCommand request, CancellationToken cancellationToken)
        {
            if (request.reactionId == Guid.Empty) return Result.Failure(Domain.Errors.ApplicationErrors.Request.EmptyRequest);

            var reaction = await _reactionRepository.GetByIdAsync(request.reactionId, cancellationToken);

            if (reaction is not null)
            {
                _reactionRepository.Remove(reaction, cancellationToken);
            }
            else
            {
                return Result.Failure(Domain.Errors.ApplicationErrors.Reaction.ReactionNotFound(request.reactionId));
            }

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
