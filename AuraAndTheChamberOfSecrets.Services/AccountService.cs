using System.Threading.Tasks;
using AuraAndTheChamberOfSecrets.Models.User;
using AuraAndTheChamberOfSecrets.Repo.Interface;
using AuraAndTheChamberOfSecrets.Services.Interface;
using Microsoft.AspNetCore.Identity;

namespace AuraAndTheChamberOfSecrets.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserProfileRepository _userProfileRepo;

        public AccountService(UserManager<ApplicationUser> userManager, IUserProfileRepository userProfileRepo)
        {
            _userManager = userManager;
            _userProfileRepo = userProfileRepo;
        }

        public async Task<IdentityResult> CreateUserAsync(ApplicationUser applicationUser, UserProfile userProfile)
        {
            var result = await _userManager.CreateAsync(applicationUser);
            if (result.Succeeded)
            {
                userProfile.ApplicationUserId = applicationUser.Id;
                await _userProfileRepo.AddAsync(userProfile);
                await _userProfileRepo.SaveAsync();
            }
            return result;
        }

        public UserProfile GetUserProfileByUsername(string username)
        {
            return _userProfileRepo.GetSingleByUsername(username);
        }
    }
}
