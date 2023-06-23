using Application.Abstractions.Messaging;
using Domain.Repositories;
using Domain.Shared;
using Domain.ValueObjects;

namespace Application.Users.Queries.GetUserByEmail
{
    internal class GetUserByEmailQueryHandler : IQueryHandler<GetUserByEmailQuery, bool>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByEmailQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<bool>> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var email = Email.Create(request.email);
            if (email.IsFailure) return Result.Failure<bool>(Domain.Errors.ApplicationErrors.User.BadEmailRequest);
            
            var user = await _userRepository.GetByEmailAsync(email.Value,cancellationToken);
            if (user is null) return Result.Success(false);
            else
                return Result.Success(true);
        }
    }
}
