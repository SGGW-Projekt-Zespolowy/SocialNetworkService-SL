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
        private User() { }
        public Email Email { get; private set; }
        public DateTime LastLoginDate { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public Degree Degree { get; private set; }
        public bool IsVerified { get; private set; }
        public string ProfilePicture { get; private set; }
        public DateTime CreationDate { get; init; }
        public Credentials Credentials { get; }
        public List<Specialization> Specializations { get; } = new List<Specialization>();
        public List<Contact> Contacts { get; } = new List<Contact>();
        public List<Follower> Followers { get; } = new List<Follower>();
        public List<Publication> Publications { get; } = new List<Publication>();
        public List<Post> Posts { get; } = new List<Post>();
        public List<Badge> Badges { get; } = new List<Badge>();
        public List<Follower> FollowedByMeUsers { get; } = new List<Follower>();
       
        public void Update(Email? email, FirstName? firstName, LastName? lastName, Degree? degree, string profilePicture)
        {
            if (email is not null) Email = email;
            if (firstName is not null) FirstName = firstName;
            if (lastName is not null) LastName = lastName;
            if (degree is not null) Degree = degree;
            if (profilePicture != string.Empty) ProfilePicture = profilePicture;
        }
    }
}
