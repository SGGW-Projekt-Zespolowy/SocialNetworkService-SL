using Domain.Entities;

namespace Application.Users.Queries.GetUserById
{
    public record GetUserByIdResponse(
        Guid id,
        string email,
        DateTime lastLoginDate,
        string firstName,
        string lastName,
        DateTime dateOfBirth,
        string Degree,
        bool isVerified,
        List<Specialization> Specializations,
        string profilePictore
        );
}
