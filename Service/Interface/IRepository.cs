using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IRepository<TEntity> : IDisposable
         where TEntity : class
    {
        Task Create(TEntity instance);

        Task Update(TEntity instance);

        Task Delete(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        Task<IQueryable<TEntity>> GetAll();

        Task SaveChanges();
    }
}
