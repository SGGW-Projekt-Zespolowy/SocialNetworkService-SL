using Application.Abstractions.Messaging;
using Microsoft.AspNetCore.Http;

namespace Application.Users.Commands.UpdateUser
{
    public record UpdateUserProfilePicCommand(Guid userId, IFormFile? image): ICommand;
    
}
