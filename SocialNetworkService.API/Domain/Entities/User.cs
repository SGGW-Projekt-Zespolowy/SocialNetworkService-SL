using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public sealed class User : Entity
    {
        public User(Guid id, string email, DateTime lastLoginDate,
            DateTime registrationDate, FirstName firstName, LastName lastName,
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
        public FirstName FirstName { get; set; }
        public LastName LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Degree Degree { get; set; }
    }
}
