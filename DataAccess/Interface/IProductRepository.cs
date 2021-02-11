using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityModels.Models;
namespace Service.Models.Interface
{
    interface IProductRepository: IDisposable
    {
        

        void Create(merch instance);

        void Update(merch instance);

        void Delete(merch instance);

        merch Get(int productID);

        IQueryable<merch> GetAll();

        void SaveChanges();
    }
}
