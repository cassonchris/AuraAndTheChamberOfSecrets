using AuraAndTheChamberOfSecrets.Models.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuraAndTheChamberOfSecrets.Repo.Context
{
    public class AuraAndTheChamberOfSecretsDbContext : IdentityDbContext<ApplicationUser>
    {
        public AuraAndTheChamberOfSecretsDbContext(DbContextOptions<AuraAndTheChamberOfSecretsDbContext> options)
            : base(options)
        {
        }

    }
}
