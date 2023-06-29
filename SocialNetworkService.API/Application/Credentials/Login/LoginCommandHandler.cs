using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Repositories;
using Domain.Shared;
using Domain.ValueObjects;
using UserErrors = Domain.Errors.ApplicationErrors.User;

namespace Application.Credentials.Login
{
    internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICredentialsRepository _credentialsRepository;
        private readonly IJwtProvider _jwtProvider;

        public LoginCommandHandler(IUserRepository userRepository, IJwtProvider jwtProvider, ICredentialsRepository credentialsRepository)
        {
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
            _credentialsRepository = credentialsRepository;
        }

        public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var email = Email.Create(request.email);
            if (email.IsFailure) return Result.Failure<string>(UserErrors.InvalidLoginCredentials);

            var user = await _userRepository.GetByEmailAsync(email.Value, cancellationToken);
            if (user is null) return Result.Failure<string>(UserErrors.InvalidLoginCredentials);

            var credentials = await _credentialsRepository.GetByUserIdAsync(user.Id);
            if (credentials is null) return Result.Failure<string>(UserErrors.UserNotFound(user.Id));

            if(!credentials.ValidatePassword(request.password))
                return Result.Failure<string>(UserErrors.InvalidLoginCredentials);

            string token = _jwtProvider.Generate(user);
            return token;
        }
    }
}
