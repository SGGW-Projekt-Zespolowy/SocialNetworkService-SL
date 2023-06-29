namespace Application.Followers.Queries.GetAllFollowedUsersByFollowerId
{
    public sealed class GetAllFollowedUsersByFollowerIdResponse
    {
        public GetAllFollowedUsersByFollowerIdResponse()
        {
            FollowedUsers = new List<FollowedUserResponse>();
        }
        public List<FollowedUserResponse> FollowedUsers { get; set; }
    }

    public class FollowedUserResponse
    {
        public FollowedUserResponse(Guid followedUserId, string firstName, string lastName, string degree, string profilePicture)
        {
            Id = followedUserId;
            FirstName = firstName;
            LastName = lastName;
            Degree = degree;
            ProfilePicture = profilePicture;
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Degree { get; set; }
        public string ProfilePicture { get; set; }
    }
}
