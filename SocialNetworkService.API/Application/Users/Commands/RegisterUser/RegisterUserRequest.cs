namespace Application.Users.Commands.RegisterUser
{
    public record RegisterUserRequest(string firstName, string lastName,
        string email, string password,DateTime dateOfBirth, string degree);
}
