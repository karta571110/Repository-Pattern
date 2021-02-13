using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service.Models.Interface;
using EntityModels.Models;
using Microsoft.EntityFrameworkCore;
using EntityModels.ViewModels;

namespace Service.Models.Repository
{
    public class ProductRepository : IProductRepository
    {
        protected RPDbContext db
        {
            get;
            private set;
        }
        public ProductRepository(RPDbContext context)
        {
            this.db=context;
        }
        public void Create(ViewMerch instance)
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
                    var item = new merch
                    {
                        Name = instance.Name,
                        Description = instance.Description,
                        Detail = instance.Detail,
                        CreateDate = time
                    };

                    //db.ViewMerches.Add(item);            
                    db.merches.Add(item);
                    this.SaveChanges();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public ViewMerch Get(int productID)
        {
            try
            {
                var instance = db.merches.FirstOrDefault(x => x.Id == productID);
                var item = new ViewMerch
                {
                    Name = instance.Name,
                    Description = instance.Description,
                    Detail = instance.Detail,
                    CreateDate = instance.CreateDate
                };
                return item;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public void Update(ViewMerch instance)
        {
            try
            {
                if (instance == null)
                {
                    throw new ArgumentNullException("instance為空");
                }
                else
                {
                    db.Entry(instance).State = EntityState.Modified;
                    this.SaveChanges();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void Delete(ViewMerch instance)
        {
            try
            {
                if (instance == null)
                {
                    throw new ArgumentNullException("instance為空");
                }
                else
                {
                    var item=
                    db.Entry(instance).State = EntityState.Deleted;
                    this.SaveChanges();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);                
            }
        }
        

        public IQueryable<ViewMerch> GetAll()
        {
            try
            {
                var getter = new List<ViewMerch>();
                var items = db.merches.OrderBy(x => x.Id).ToList();
                foreach (var e in items)
                {
                    getter.Add(new ViewMerch
                    {
                        Name = e.Name,
                        CreateDate = e.CreateDate,
                        Description = e.Description,
                        Detail = e.Detail
                    });
                }
                return getter.AsQueryable();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
           
        }

        public void SaveChanges()
        {
            db.SaveChanges();
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
