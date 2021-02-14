using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
   public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        Task Create(TEntity instance);

        Task Update(TEntity instance);

        Task Delete(int id=-1);

        Task<TEntity> Get(int primaryID);

        Task<IQueryable<TEntity>> GetAll();

        Task SaveChanges();
    }
}
