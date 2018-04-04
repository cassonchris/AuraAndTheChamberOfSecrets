using AuraAndTheChamberOfSecrets.Models.User;
using AuraAndTheChamberOfSecrets.Repo.EntityFramework.Context;
using AuraAndTheChamberOfSecrets.Repo.Interface;

namespace AuraAndTheChamberOfSecrets.Repo.EntityFramework
{
    public class UserProfileRepository : BaseRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(AuraAndTheChamberOfSecretsDbContext context) : base(context)
        {
        }
    }
}
