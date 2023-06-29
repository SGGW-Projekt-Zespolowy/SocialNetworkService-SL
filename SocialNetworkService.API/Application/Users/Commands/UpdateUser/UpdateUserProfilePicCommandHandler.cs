using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Entities;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Users.Commands.UpdateUser
{
    public sealed class UpdateUserProfilePicCommandHandler : ICommandHandler<UpdateUserProfilePicCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public UpdateUserProfilePicCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<Result> Handle(UpdateUserProfilePicCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.userId, cancellationToken);
            if (user is null)
            {
                return Result.Failure(Domain.Errors.ApplicationErrors.User.UserNotFound(request.userId));
            }

            string? dbImage = null;
            if (request.image is not null)
                dbImage = Image.Encode(request.image, Guid.Empty).Value.Data;

            user.Update(null,null,null,null,dbImage);
            _userRepository.Update(user, cancellationToken);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
