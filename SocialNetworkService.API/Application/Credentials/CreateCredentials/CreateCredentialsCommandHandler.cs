using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Credentials.CreateCredentials
{
    public class CreateCredentialsCommandHandler : ICommandHandler<CreateCredentialsCommand>
    {
        private readonly ICredentialsRepository _credentialsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCredentialsCommandHandler(ICredentialsRepository credentialsRepository, IUnitOfWork unitOfWork)
        {
            _credentialsRepository = credentialsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateCredentialsCommand request, CancellationToken cancellationToken)
        {
            var credentials = Domain.Entities.Credentials.Create(request.userId,request.password);
            _credentialsRepository.Add(credentials);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
