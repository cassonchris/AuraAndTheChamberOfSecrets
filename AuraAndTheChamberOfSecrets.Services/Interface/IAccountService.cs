using System.Threading.Tasks;
using AuraAndTheChamberOfSecrets.Models.User;
using Microsoft.AspNetCore.Identity;

namespace AuraAndTheChamberOfSecrets.Services.Interface
{
    public interface IAccountService
    {
        Task<IdentityResult> CreateUserAsync(ApplicationUser applicationUser, UserProfile userProfile);
        UserProfile GetUserProfileByUsername(string username);
    }
}
