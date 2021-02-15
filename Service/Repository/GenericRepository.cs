using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Service.Interface;
//using Service.Models.Repository;

namespace Service.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private bool disposedValue;

        protected RPDbContext db
        {
            get;
            private set;
        }
        public GenericRepository(RPDbContext context)
        {
            this.db = context;
        }
        public async Task Create(TEntity instance)
        {
            try
            {
                if (instance == null)
                {
                    throw new ArgumentNullException("instance為空");
                }
                else
                {
                    await db.Set<TEntity>().AddAsync(instance);
                    await this.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task Delete(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                
                    var DeItem = await db.Set<TEntity>().FirstAsync(predicate);
                    db.Entry(DeItem).State = EntityState.Deleted;
                    await this.SaveChanges();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var instance = await db.Set<TEntity>().FirstOrDefaultAsync(predicate);
                
                return instance;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Get 有問題");
                return null;
            }
        }

        public async Task<IQueryable<TEntity>> GetAll()
        {
            try
            {
                var items =  db.Set<TEntity>().AsQueryable();
                return items;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("GetAll有問題");
                return null;
            }
        }

        public async Task SaveChanges()
        {
            try
            {
                await this.db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("SaveChange有問題");
            }
        }

        public Task Update(TEntity instance)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._context != null)
                {
                    this._context.Dispose();
                    this._context = null;
                }
            }
        }
    }
}
