
using Domain.Shared;

namespace Domain.Errors
{
    public static class ApplicationErrors
    {
        public static class User
        {
            public static Error UserNotFound(Guid userId) => new Error("User.NotFound", $"User with id {userId} was not found.");
            public static Error UserNameNotFound(string fullName) => new Error("User.NotFound", $"User with name: {fullName} was not found.");
            public static Error UserEmailNotFound(string email) => new Error("User.NotFound", $"User with email: {email} was not found.");

            public static readonly Error EmptyRequest = new Error("Request.Empty", "Your request is empty");

            public static readonly Error InvalidLoginCredentials = new Error("Credentials.Invalid", "Login Credentials are invalid");
                      
        }
        public static class Post
        {
            public static Error PostNotFound(Guid id) => new Error("Post.NotFound", $"Post with id={id} was not found");
        }
        public static class Image
        {
            public static Error ImagesNotFound(Guid id) => new Error("Images.NotFound", $"No Images have been found for post with id={id}.");
        }
    }
}
