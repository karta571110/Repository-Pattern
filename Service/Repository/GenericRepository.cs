using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Interface;
using Service.Models.Repository;

namespace Service.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected RPDbContext db
        {
            get;
            private set;
        }
       public GenericRepository(RPDbContext context)
        {
            this.db = context;
        } 
        public Task Create(TEntity instance)
        {
            try
            {
                if (instance == null)
                {
                    throw new ArgumentNullException("instance為空");
                }
                else
                {
                    var time = DateTime.Now;
                    var item = new whatever
                    {
                        Name = instance.Name,
                        Description = instance.Description,
                        Detail = instance.Detail,
                        CreateDate = time
                    };


                   await db.whatevers.AddAsync(item);
                    await this.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public Task Delete(int id = -1)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Get(int primaryID)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<TEntity>> GetAll()
        {
            throw new NotImplementedException();
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
    }
}
