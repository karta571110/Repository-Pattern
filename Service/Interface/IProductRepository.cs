using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityModels.Models;
using EntityModels.ViewModels;

namespace Service.Models.Interface
{
    interface IProductRepository: IDisposable
    {
        

        void Create(ViewMerch instance);

        void Update(ViewMerch instance);

        void Delete(ViewMerch instance);

        ViewMerch Get(int productID);

        IQueryable<ViewMerch> GetAll();

        void SaveChanges();
    }
}
