using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Entities;
using Domain.Repositories;
using Domain.Shared;
using Domain.ValueObjects;

namespace Application.Users.Commands.CreateUser
{
    public sealed class CreateUserCommandHandler: ICommandHandler<CreateUserCommand,User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var id = new Guid();
            var firstName = FirstName.Create(request.firstName);
            if (firstName.IsFailure)
                return Result.Failure<User>(firstName.Error);
            var lastName = LastName.Create(request.lastName);
            if (lastName.IsFailure)
                return Result.Failure<User>(lastName.Error);
            var emailResult = Email.Create(request.email);
            if (emailResult.IsFailure)
                return Result.Failure<User>(emailResult.Error);
            var degree = Degree.Create(request.degree);      
            if (degree.IsFailure)
                return Result.Failure<User>(degree.Error);

            var user = new User(id,emailResult.Value, firstName.Value, lastName.Value,
                request.dateOfBirth, degree.Value, string.Empty);

            _userRepository.Add(user,cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(user);
        }
        
    }
}
