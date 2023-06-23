using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Entities;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Users.Commands.DeleteUser
{
    public class DeleteUserByIdCommandHandler : ICommandHandler<DeleteUserByIdCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserByIdCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            if (request.userId == Guid.Empty) return Result.Failure(Domain.Errors.ApplicationErrors.Request.EmptyRequest);

            var user = await _userRepository.GetByIdAsync(request.userId, cancellationToken);

            if(user is not null)
            {
                _userRepository.Remove(user, cancellationToken);
            }
            else
            {
                return Result.Failure(Domain.Errors.ApplicationErrors.User.UserNotFound(request.userId));
            }
            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
