using System.Linq;
using AuraAndTheChamberOfSecrets.Models.User;
using AuraAndTheChamberOfSecrets.Repo.EntityFramework.Context;
using AuraAndTheChamberOfSecrets.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace AuraAndTheChamberOfSecrets.Repo.EntityFramework
{
    public class UserProfileRepository : BaseRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(AuraAndTheChamberOfSecretsDbContext context) : base(context)
        {
        }

        public UserProfile GetSingleByUsername(string username)
        {
            return DbSet
                .Include(u => u.OrganizationLinks)
                .ThenInclude(ol => ol.Organization)
                .SingleOrDefault(u => u.Username == username);
        } 
    }
}
