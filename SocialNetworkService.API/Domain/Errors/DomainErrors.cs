using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Errors
{
    public static class DomainErrors
    {
        public static class ValueObjects
        {
            public static readonly Error FirstNameIsInvalid = new Error("FirstName.IsInvalid", "FirstName is invalid");
            public static readonly Error FirstNameNotFound = new Error("FirstName.Empty", "First name is empty.");
            public static readonly Error FirstNameTooLong = new Error("FirstName.TooLong", "First name is too long.");
            public static readonly Error LastNameIsInvalid = new Error("LastName.IsInvalid", "LastName is invalid");
            public static readonly Error EmailIsInvalid = new Error("Email.Invalid", "Email is invalid.");
            public static readonly Error DegreeIsInvalid = new Error("Degree.IsInvalid", "Degree is invalid");
        }
    }
}
