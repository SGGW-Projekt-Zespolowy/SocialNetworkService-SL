using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Repositories;
using Domain.Shared;
using Domain.ValueObjects;

namespace Application.Users.Commands.Login
{
    public sealed class LoginCommandHandler : ICommandHandler<LoginCommand, string>
    {
        IUserRepository _userRepository;
        IJwtProvider _jwtProvider;

        public LoginCommandHandler(IUserRepository userRepository, IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
        }

        public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var email = Email.Create(request.email);
            if(email.IsFailure) return Result.Failure<string>(Domain.Errors.ApplicationErrors.User.InvalidLoginCredentials);

            var user = await _userRepository.GetByEmailAsync(email.Value,cancellationToken);
            if (user is null) return Result.Failure<string>(Domain.Errors.ApplicationErrors.User.InvalidLoginCredentials);

            string token = _jwtProvider.Generate(user);
            return token;
        }
    }
}
