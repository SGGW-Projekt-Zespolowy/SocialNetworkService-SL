using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class User : Entity
    {
        public User(Guid id, string email, DateTime lastLoginDate,
            DateTime registrationDate, string firstName, string lastName,
            DateTime dateOfBirth, Degree degree) :
            base(id)
        {
            Email = email;
            LastLoginDate = lastLoginDate;
            RegistrationDate = registrationDate;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Degree = degree;
        }
        public string Email { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Degree Degree { get; set; }
    }
}
