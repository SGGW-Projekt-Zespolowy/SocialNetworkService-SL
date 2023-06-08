namespace Application.Users.Queries.GetUserByFullName
{
    public record GetUserByFullNameResponse(
        Guid id,
        string email,
        DateTime lastLoginDate,
        string firstName,
        string lastName,
        DateTime dateOfBirth,
        string Degree,
        bool isVerified,
        string profilePictore);
}
