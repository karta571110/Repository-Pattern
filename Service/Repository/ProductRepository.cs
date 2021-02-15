//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Service.Models.Interface;
//using EntityModels.Models;
//using Microsoft.EntityFrameworkCore;
//using EntityModels.ViewModels;
//using System.Threading.Tasks;

//namespace Service.Models.Repository
//{
//    public class ProductRepository : IProductRepository
//    {
//        protected RPDbContext db
//        {
//            get;
//            private set;
//        }
//        public ProductRepository(RPDbContext context)
//        {
//            this.db = context;
//        }
//        public async Task Create(ViewMerch instance)
//        {
//            try
//            {
//                if (instance == null)
//                {
//                    throw new ArgumentNullException("instance為空");
//                }
//                else
//                {
//                    var time = DateTime.Now;
//                    var item = new merch
//                    {
//                        Name = instance.Name,
//                        Description = instance.Description,
//                        Detail = instance.Detail,
//                        CreateDate = time
//                    };

//                    //db.ViewMerches.Add(item);            
//                    db.merches.Add(item);
//                    await this.SaveChanges();
//                }
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//            }
//        }
//        public async Task<ViewMerch> Get(int productID)
//        {
//            try
//            {
//                var instance =await db.merches.FirstOrDefaultAsync(x => x.Id == productID);
//                var item = new ViewMerch
//                {
//                    Name = instance.Name,
//                    Description = instance.Description,
//                    Detail = instance.Detail,
//                    CreateDate = instance.CreateDate
//                };
//                return item;
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//                return null;
//            }
//        }
//        public async Task Update(ViewMerch instance)
//        {
//            try
//            {
//                if (instance == null)
//                {
//                    throw new ArgumentNullException("instance為空");
//                }
//                else
//                {    
//                    var upItem = new merch
//                    {
//                        Id=instance.Id,
//                        Name=instance.Name,
//                        Description=instance.Description,
//                        Detail=instance.Detail,
//                        CreateDate=instance.CreateDate
//                    };
//                    db.Entry(upItem).State = EntityState.Modified;
//                    await this.SaveChanges();
//                }
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//            }
//        }
//        public async Task Delete(int id = -1)
//        {
//            try
//            {
//                if (id == -1)
//                {
//                    throw new ArgumentNullException("instance為空");
//                }
//                else
//                {
//                    var item = await db.merches.FirstAsync(e => e.Id == id);
//                    db.Entry(item).State = EntityState.Deleted;
//                    await this.SaveChanges();
//                }
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//            }
//        }


//        public async Task<IQueryable<ViewMerch>> GetAll()
//        {
//            try
//            {
//                var getter = new List<ViewMerch>();
//                var items =await db.merches.OrderBy(x => x.Id).ToListAsync();
//                foreach (var e in items)
//                {
//                    getter.Add(new ViewMerch
//                    {
//                        Name = e.Name,
//                        CreateDate = e.CreateDate,
//                        Description = e.Description,
//                        Detail = e.Detail
//                    });
//                }
//                return getter.AsQueryable();
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//                return null;
//            }

//        }

//        public async Task SaveChanges()
//        {
//            await db.SaveChangesAsync();
//        }


//        public void Dispose()
//        {
//            this.Dispose(true);
//            GC.SuppressFinalize(this);
//        }
//        protected virtual void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                if (this.db != null)
//                {
//                    this.db.Dispose();
//                    this.db = null;
//                }
//            }
//        }

//    }
//}
