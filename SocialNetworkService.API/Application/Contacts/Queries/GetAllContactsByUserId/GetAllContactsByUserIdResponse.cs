using Application.Posts.Queries.GetByScope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contacts.Queries.GetAllContactsByUserId
{
    public sealed class GetAllContactsByUserIdResponse
    {
        public GetAllContactsByUserIdResponse()
        {
            Contacts = new List<ContactResponse>();
        }
        public List<ContactResponse> Contacts { get; set; }
    }

    public class ContactResponse
    {
        public ContactResponse(Guid id, string firstName, string lastName, string  degree, string profilePicture)
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
