using Microsoft.AspNetCore.Identity;

namespace AuraAndTheChamberOfSecrets.Models.User
{
    public class ApplicationUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
