using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AuraAndTheChamberOfSecrets.Repo.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        T GetSingleById(Guid id);
        IQueryable<T> Query(Expression<Func<T, bool>> query);
        Task SaveAsync();
    }
}
