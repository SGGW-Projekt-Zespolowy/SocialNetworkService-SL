using Application.Abstractions.Messaging;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, GetUserByIdResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.userId, cancellationToken);

            if (user == null)
            {
                return Result.Failure<GetUserByIdResponse>(Domain.Errors.ApplicationErrors.User.UserNotFound(request.userId));
            }

            var imageData = string.Format("data:image/png;base64,{0}", user.ProfilePicture);

            var response = new GetUserByIdResponse(
                user.Id, user.Email, user.LastLoginDate, user.FirstName, user.LastName,
                user.DateOfBirth, user.Degree, user.IsVerified, user.Specializations, imageData);
            return Result.Success(response);
        }
    }
}
