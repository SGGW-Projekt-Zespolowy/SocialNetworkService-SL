using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public sealed class User : AggregateRoot
    {
        public User(Guid id, Email email,
            FirstName firstName, LastName lastName,
            DateTime dateOfBirth, Degree degree, string profilePicture) :
            base(id)
        {
            Email = email;
            LastLoginDate = DateTime.Now;
            RegistrationDate = DateTime.Now;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            CreationDate = DateTime.Now;
            Degree = degree;
            IsVerified = false;
            ProfilePicture = profilePicture;
        }
        public Email Email { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public FirstName FirstName { get; set; }
        public LastName LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Degree Degree { get; set; }
        public bool IsVerified { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime CreationDate { get; init; }
        public List<Specialization> Specializations { get; } = new List<Specialization>();
        public List<Contact> Contacts { get; } = new List<Contact>();
        public List<Follower> Followers { get; } = new List<Follower>();
        public List<Publication> Publications { get; } = new List<Publication>();
        public List<Post> Posts { get; } = new List<Post>();
        public List<Badge> Badges { get; } = new List<Badge>();
        
    }
}
