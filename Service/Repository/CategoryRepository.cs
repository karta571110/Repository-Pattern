using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service.Models.Interface;
using EntityModels.ViewModels;
using EntityModels.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Service.Models.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        protected RPDbContext db
        {
            get;
            private set;
        }
        public CategoryRepository(RPDbContext context)
        {
            this.db = context;
        }
        public async Task Create(Viewwhatever instance)
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


                    db.whatevers.Add(item);
                    await this.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task Delete(Viewwhatever instance)
        {
            try
            {
                if (instance == null)
                {
                    throw new ArgumentNullException("instance為空");
                }
                else
                {
                    var DeItem = new whatever
                    {
                        Id = instance.Id,
                        Name = instance.Name,
                        Description = instance.Description,
                        Detail = instance.Detail,
                        CreateDate = instance.CreateDate
                    };
                    db.Entry(DeItem).State = EntityState.Deleted;
                    await this.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task<Viewwhatever> Get(int categoryID)
        {
            try
            {
                var instance = await db.whatevers.FirstOrDefaultAsync(x => x.Id == categoryID);
                var item = new Viewwhatever
                {
                    Id = instance.Id,
                    Name = instance.Name,
                    Description = instance.Description,
                    Detail = instance.Detail,
                    CreateDate = instance.CreateDate
                };
                return item;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Get 有問題");
                return null;
            }
        }

        public async Task<IQueryable<Viewwhatever>> GetAll()
        {
            try
            {
                var getter = new List<Viewwhatever>();
                var items = await db.whatevers.OrderBy(x => x.Id).ToListAsync();

                foreach (var e in items)
                {
                    getter.Add(new Viewwhatever
                    {
                        Id = e.Id,
                        Name = e.Name,
                        CreateDate = e.CreateDate,
                        Description = e.Description,
                        Detail = e.Detail
                    });
                }
                return getter.AsQueryable();
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

        public async Task Update(Viewwhatever instance)
        {
            ///Console.WriteLine(instance);
            try
            {
                if (instance == null)
                {
                    throw new ArgumentNullException("instance為空");
                }
                else
                {
                    var upItem = new whatever
                    {
                        Id = instance.Id,
                        Name = instance.Name,
                        Description = instance.Description,
                        Detail = instance.Detail

                    };
                    db.Entry(upItem).State = EntityState.Modified;
                    await this.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
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
                if (this.db != null)
                {
                    this.db.Dispose();
                    this.db = null;
                }
            }
        }


    }
}
