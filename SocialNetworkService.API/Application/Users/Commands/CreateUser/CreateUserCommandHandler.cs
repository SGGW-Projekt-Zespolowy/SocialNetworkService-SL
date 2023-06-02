using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Entities;
using Domain.Repositories;
using Domain.Shared;
using Domain.ValueObjects;

namespace Application.Users.Commands.CreateUser
{
    public sealed class CreateUserCommandHandler: ICommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var emailResult = Email.Create(request.email);
            var firstName = FirstName.Create(request.firstName);
            var lastName = LastName.Create(request.lastName);
            var degree = Degree.Create(request.degree);
            var id = new Guid();

            var user = new User(id,emailResult.Value, firstName.Value, lastName.Value,
                request.dateOfBirth, degree.Value, request.profilePicture);

            _userRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
        
    }
}
