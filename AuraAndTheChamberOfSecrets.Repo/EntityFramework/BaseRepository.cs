using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AuraAndTheChamberOfSecrets.Repo.EntityFramework.Context;
using AuraAndTheChamberOfSecrets.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace AuraAndTheChamberOfSecrets.Repo.EntityFramework
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected AuraAndTheChamberOfSecretsDbContext Context { get; }
        protected DbSet<T> DbSet { get; }

        public BaseRepository(AuraAndTheChamberOfSecretsDbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public virtual T GetSingleById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<T> Query(Expression<Func<T, bool>> query)
        {
            return DbSet.Where(query);
        }

        public async Task AddAsync(T t)
        {
            await DbSet.AddAsync(t);
        }

        public virtual async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
