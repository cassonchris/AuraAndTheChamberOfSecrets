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
        private readonly AuraAndTheChamberOfSecretsDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(AuraAndTheChamberOfSecretsDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }


        public virtual T GetSingleById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public virtual IQueryable<T> Query(Expression<Func<T, bool>> query)
        {
            return _dbSet.Where(query);
        }

        public async Task AddAsync(T t)
        {
            await _dbSet.AddAsync(t);
        }

        public virtual async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
