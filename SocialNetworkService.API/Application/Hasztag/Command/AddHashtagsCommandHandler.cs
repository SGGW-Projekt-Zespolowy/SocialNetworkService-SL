using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Entities;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Hasztag.Command
{
    public sealed class AddHashtagsCommandHandler : ICommandHandler<AddHashtagsCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHashtagRepository _repository;

        public AddHashtagsCommandHandler(IUnitOfWork unitOfWork, IHashtagRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<Result> Handle(AddHashtagsCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                return Result.Failure(Domain.Errors.ApplicationErrors.General.BadRequest);

            foreach(var name in request.names)
            {
                var hashtag = new Hashtag(Guid.NewGuid(), name, request.relatedItemId);
                _repository.Add(hashtag, cancellationToken);
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
