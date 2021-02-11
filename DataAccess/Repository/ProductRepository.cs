using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service.Models.Interface;
using EntityModels.Models;
using Microsoft.EntityFrameworkCore;

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
        public void Create(merch instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance為空");
            }
            else
            {
                //var time = DateTime.Now;
                //var item = new merch
                //{
                //    Name = instance.Name,
                //    Description = instance.Description,
                //    Detail = instance.Detail,
                //    CreateDate = time
                //};

                //db.merches.Add(item);            
                db.merches.Add(instance);
                this.SaveChanges();
            }
           
        }
        public merch Get(int productID)
        {
            return db.merches.FirstOrDefault(x => x.Id == productID);
        }
        public void Update(merch instance)
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
        public void Delete(merch instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance為空");
            }
            else
            {
                db.Entry(instance).State = EntityState.Deleted;
                this.SaveChanges();
            }
        }
        

        public IQueryable<merch> GetAll()
        {
            return db.merches.OrderBy(x => x.Id);
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
