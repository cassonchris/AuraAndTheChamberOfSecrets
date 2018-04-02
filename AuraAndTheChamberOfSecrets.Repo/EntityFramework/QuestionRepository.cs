using AuraAndTheChamberOfSecrets.Models;
using AuraAndTheChamberOfSecrets.Repo.EntityFramework.Context;
using AuraAndTheChamberOfSecrets.Repo.Interface;

namespace AuraAndTheChamberOfSecrets.Repo.EntityFramework
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(AuraAndTheChamberOfSecretsDbContext context) : base(context)
        {
        }
    }
}
