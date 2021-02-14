using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityModels.Models;
using EntityModels.ViewModels;

namespace Service.Models.Interface
{
    public interface ICategoryRepository : IDisposable
    {
        Task Create(Viewwhatever instance);

        Task Update(Viewwhatever instance);

        Task Delete(int id);

        Task<Viewwhatever> Get(int categoryID);

        Task<IQueryable<Viewwhatever>> GetAll();

        Task SaveChanges();
    }
}
