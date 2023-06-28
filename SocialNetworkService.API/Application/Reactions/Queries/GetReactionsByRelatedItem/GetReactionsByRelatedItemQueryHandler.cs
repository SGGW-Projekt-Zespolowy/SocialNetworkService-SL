using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Repositories;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reactions.Queries.GetReactionsByRelatedItem
{
    public class GetReactionsByRelatedItemQueryHandler : IQueryHandler<GetReactionsByRelatedItemQuery, GetReactionsByRelatedItemResponse>
    {
        private readonly IReactionRepository _reactionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetReactionsByRelatedItemQueryHandler(IReactionRepository reactionRepository, IUnitOfWork unitOfWork)
        {
            _reactionRepository = reactionRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<GetReactionsByRelatedItemResponse>> Handle(GetReactionsByRelatedItemQuery request, CancellationToken cancellationToken)
        {
            var reactions = await _reactionRepository.GetByRelatedItemId(request.relatedItemId, cancellationToken);

            if (reactions.Count == 0)
            {
                return Result.Failure<GetReactionsByRelatedItemResponse>(Domain.Errors.ApplicationErrors.Reaction.NoReactionsFound);
            }

            var response = new GetReactionsByRelatedItemResponse();

            foreach (var reaction in reactions)
            {
                response.Reactions.Add(new ReactionResponse(
                    reaction.Id,
                    reaction.ReactionType.Value,
                    reaction.AuthorId));
            }

            return Result.Success(response);
        }
    }
}
