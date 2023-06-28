
using Domain.Shared;

namespace Domain.Errors
{
    public static class ApplicationErrors
    {
        public static class General
        {
            public static readonly Error NullRequest = new Error("Request.IsNull", "Your request is null");
        }
        public static class PostBookmark
        {
            public static readonly Error EmptyUserId = new Error("UserId.IsEmpty", "Your UserId is empty");
            public static readonly Error EmptyPostId = new Error("PostId.IsEmpty", "Your PostId is empty");
            public static readonly Error BookmarkNotFound = new Error("Bookmark.NotFound", "Bookmark was not found");
        }
        public static class Request
        {
            public static readonly Error EmptyRequest = new Error("Request.Empty", "Your request is empty");
        }
        public static class User
        {
            public static Error UserNotFound(Guid userId) => new Error("User.NotFound", $"User with id {userId} was not found.");
            public static readonly Error InvalidLoginCredentials = new Error("Credentials.Invalid", "Login Credentials are invalid");
            public static Error UserEmailNotFound(string email) => new Error("User.NotFound", $"User with email: {email} was not found.");
            public static Error UserNameNotFound(string fullName) => new Error("User.NotFound", $"User with name: {fullName} was not found.");
            
            public static readonly Error BadEmailRequest = new Error("UserEmail.Invalid", "Bad Email Request");
        }

        public static class Post
        {
            public static Error PostNotFound(Guid postId) => new Error("Post.NotFound", $"Post with id {postId} was not found.");
        }

            
        public static class Publication
        {
            public static Error PublicationNotFound(Guid publicationId) => new Error("Publication.NotFound", $"Publication with id {publicationId} was not found.");
        }

        public static class Comment
        {
            public static Error CommentNotFound(Guid commentId) => new Error("Comment.NotFound", $"Comment with id {commentId} was not found.");
        }
        public static class Image
        {
            public static Error ImagesNotFound(Guid id) => new Error("Images.NotFound", $"No Images have been found for post with id={id}.");
        }
    }
}
