﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service.Models.Interface;
using EntityModels.ViewModels;
using EntityModels.Models;
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
        public void Create(whatever instance)
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
                db.whatevers.Add(instance);
                this.SaveChanges();
            }
        }

        public void Delete(whatever instance)
        {
            throw new NotImplementedException();
        }

        public whatever Get(int categoryID)
        {
            throw new NotImplementedException();
        }

        public IQueryable<whatever> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(whatever instance)
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
                if (this.db != null)
                {
                    this.db.Dispose();
                    this.db = null;
                }
            }
        }
    }
}
