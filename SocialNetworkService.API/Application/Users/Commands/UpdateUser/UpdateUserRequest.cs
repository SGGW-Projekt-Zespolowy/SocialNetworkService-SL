using Microsoft.AspNetCore.Http;

namespace Application.Users.Commands.UpdateUser
{
    public sealed class UpdateUserRequest
    {
        public UpdateUserRequest(Guid userId, string email, string firstName, string lastName, string degree)
        {
            UserId = userId;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Degree = degree;
        }

        public Guid UserId { get; private set; }
        public string Email { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Degree { get; private set; }
    }
}
