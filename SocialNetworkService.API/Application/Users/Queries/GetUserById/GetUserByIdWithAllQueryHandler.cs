using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Users.Queries.GetUserById
{
    public class GetUserByIdWithAllQueryHandler : IQueryHandler<GetUserByIdWithAllQuery, GetUserByIdWithAllResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetUserByIdWithAllQueryHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetUserByIdWithAllResponse>> Handle(GetUserByIdWithAllQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdWithAllAsync(request.userId,cancellationToken);
            if (user == null)
            {
                return Result.Failure<GetUserByIdWithAllResponse>(Domain.Errors.ApplicationErrors.User.UserNotFound(request.userId));
            }

            var response = new GetUserByIdWithAllResponse(user.Id,user.Email.Value,user.LastLoginDate,user.RegistrationDate,
                user.FirstName.Value,user.LastName.Value,user.DateOfBirth,user.Degree,user.IsVerified,user.ProfilePicture,
                user.Specializations,user.Contacts,user.Followers,user.Publications,user.Posts,user.Badges,user.FollowedByMeUsers);
            return Result.Success(response);
        }
    }
}
