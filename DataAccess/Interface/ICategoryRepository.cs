using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityModels.Models;
namespace Service.Models.Interface
{
   public interface ICategoryRepository: IDisposable
    {
        void Create(whatever instance);

        void Update(whatever instance);

        void Delete(whatever instance);

        whatever Get(int categoryID);

        IQueryable<whatever> GetAll();

        void SaveChanges();
    }
}
