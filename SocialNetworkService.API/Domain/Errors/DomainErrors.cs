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
            public static readonly Error FirstNameIsInvalid = new Error("FirstName.IsInvalid", "First name is invalid");
            public static readonly Error FirstNameNotFound = new Error("FirstName.Empty", "First name is empty.");
            public static readonly Error FirstNameTooLong = new Error("FirstName.TooLong", "First name is too long.");
            public static readonly Error LastNameIsInvalid = new Error("LastName.IsInvalid", "Last name is invalid");
            public static readonly Error LastNameNotFound = new Error("LastName.Empty", "Last name is empty");
            public static readonly Error LastNameTooLong = new Error("LastName.TooLong", "Last name is too long");
            public static readonly Error EmailIsInvalid = new Error("Email.Invalid", "Email is invalid.");
            public static readonly Error EmailNotFound = new Error("Email.NotFound", "Email is empty.");
            public static readonly Error EmailTooLong = new Error("Email.TooLong", "Email is too long.");
            public static readonly Error DegreeNotDefined = new Error("Degree.NotDefined", "Degree is not defined");
            public static readonly Error DegreeNotFound = new Error("Degree.NotFound", "Degree is empty.");
            public static readonly Error ContentNotFound = new Error("Content.NotFound", "Content is empty.");
            public static readonly Error ContentTooLong = new Error("Content.TooLong", "Content is too long.");
            public static readonly Error LinkIsInvalid = new Error("Link.Invalid", "Link is invalid.");
            public static readonly Error LinkNotFound = new Error("Link.NotFound", "Link is empty.");
            public static readonly Error LinkTooLong = new Error("Link.TooLong", "Link is too long.");
            public static readonly Error MedicalSpecializationNotDefined = new Error("MedicalSpecialization.NotDefined", "Medical specialization is not defined");
            public static readonly Error MedicalSpecializationNotFound = new Error("MedicalSpecialization.NotFound", "Medical specialization is empty.");
            public static readonly Error ReactionNotDefined = new Error("Reaction.NotDefined", "Reaction is not defined");
            public static readonly Error ReactionNotFound = new Error("Reaction.NotFound", "Reaction is empty.");
            public static readonly Error TitleNotFound = new Error("Title.NotFound", "Title is empty.");
            public static readonly Error TitleTooLong = new Error("Title.TooLong", "Title is too long.");
        }
    }
}
