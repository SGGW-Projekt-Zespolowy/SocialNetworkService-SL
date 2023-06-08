using Domain.Entities;

namespace Application.Users.Queries.GetUserById
{
    public record GetUserByIdWithAllResponse(
        Guid id, string email, DateTime lastLogin, DateTime registrationTime, string firstName, string lastName, 
        DateTime dateOfBirth, string defree, bool isVerifired, string profilePicture, List<Specialization> specializations,
        List<Contact> contacts, List<Follower> followers, List<Publication> publications, List<Post> posts, List<Badge> badges, 
        List<Follower> followedByMeUsers);
}
