using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Followers.Queries.GetAllFollowersByUserId
{
    public sealed class GetAllFollowersByFollowerIdResponse
    {
        public GetAllFollowersByFollowerIdResponse()
        {
            Followers = new List<FollowerResponse>();
        }
        public List<FollowerResponse> Followers { get; set; }
    }

    public class FollowerResponse
    {
        public FollowerResponse(Guid id, string firstName, string lastName, string degree, string profilePicture)
        {
            Id = id;
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
