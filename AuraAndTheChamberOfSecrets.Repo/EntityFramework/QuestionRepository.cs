using System;
using System.Linq;
using AuraAndTheChamberOfSecrets.Models;
using AuraAndTheChamberOfSecrets.Repo.EntityFramework.Context;
using AuraAndTheChamberOfSecrets.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace AuraAndTheChamberOfSecrets.Repo.EntityFramework
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(AuraAndTheChamberOfSecretsDbContext context) : base(context)
        {
        }

        /// <summary>
        /// todo - eww, include references by default
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Question GetSingleById(Guid id)
        {
            return DbSet
                .Include(q => q.Organization)
                .Include(q => q.User)
                .Include(q => q.Answers)
                .SingleOrDefault(q => q.Id == id);
        }
    }
}
